Questão 3 – Padrões Criacionais e Injeção de Dependência
Cenário Proposto

O exemplo gira em torno de uma conexão com uma API de usuários.
A classe APIConnection simula uma conexão com uma API (por exemplo: https://api.exemplo.com
), e o serviço UserService utiliza essa conexão para buscar informações de usuários.

A seguir, o mesmo cenário é implementado de quatro formas diferentes, demonstrando a evolução dos padrões criacionais até a abordagem moderna com Injeção de Dependência (DI).

1. Singleton Pattern

Ideia
Garante que apenas uma instância da classe exista em todo o sistema.

Aplicação
Usado quando é necessário controlar um recurso global, como logs, cache ou configurações.

class APIConnection:
    _instance = None

    def __new__(cls, base_url):
        # Se ainda não existe instância, cria uma
        if cls._instance is None:
            print("Criando conexão única com a API...")
            cls._instance = super(APIConnection, cls).__new__(cls)
            cls._instance.base_url = base_url
        # Retorna sempre a mesma instância
        return cls._instance

    def get(self, endpoint):
        print(f"[GET] {self.base_url}/{endpoint}")

class UserService:
    def __init__(self):
        # O serviço depende diretamente do Singleton
        self.api = APIConnection("https://api.exemplo.com")

    def get_user(self, user_id):
        self.api.get(f"users/{user_id}")

# Testando
service1 = UserService()
service2 = UserService()
service1.get_user(1)
service2.get_user(2)
print(service1.api is service2.api)  # True → é a mesma instância


Desvantagens
Cria dependências globais difíceis de controlar, prejudica testes e aumenta o acoplamento entre as classes.

2. Abstract Factory Pattern

Ideia
Fornece uma interface para criar famílias de objetos relacionados sem expor suas classes concretas.

Aplicação
Usado quando há diferentes variações de objetos (por exemplo, conexões de API para ambientes de produção e teste).

# Interface base para conexões
class APIConnection:
    def get(self, endpoint):
        raise NotImplementedError

# Conexão real de produção
class ProductionAPIConnection(APIConnection):
    def __init__(self):
        self.base_url = "https://api.exemplo.com"
        print("Conexão de PRODUÇÃO criada")

    def get(self, endpoint):
        print(f"[GET] {self.base_url}/{endpoint}")

# Conexão de teste
class TestAPIConnection(APIConnection):
    def __init__(self):
        self.base_url = "https://api.teste.com"
        print("Conexão de TESTE criada")

    def get(self, endpoint):
        print(f"[GET] {self.base_url}/{endpoint}")

# Fábrica abstrata
class APIConnectionFactory:
    def create_connection(self):
        raise NotImplementedError

# Fábricas concretas
class ProductionFactory(APIConnectionFactory):
    def create_connection(self):
        return ProductionAPIConnection()

class TestFactory(APIConnectionFactory):
    def create_connection(self):
        return TestAPIConnection()

# Serviço que usa a fábrica
class UserService:
    def __init__(self, factory: APIConnectionFactory):
        # O serviço não sabe qual tipo de conexão será usada
        self.api = factory.create_connection()

    def get_user(self, user_id):
        self.api.get(f"users/{user_id}")

# Testando
factory = ProductionFactory()
service_prod = UserService(factory)
service_prod.get_user(5)

factory_teste = TestFactory()
service_teste = UserService(factory_teste)
service_teste.get_user(99)


Desvantagens
É um padrão mais verboso, com muitas classes apenas para criação de objetos.
Em frameworks modernos, ele é raramente necessário, pois a DI já resolve o mesmo problema com menos código.

3. Prototype Pattern

Ideia
Cria novos objetos clonando um protótipo existente, em vez de instanciá-los diretamente.

Aplicação
Usado quando a criação de objetos é custosa, e clonar é mais eficiente.

import copy

class APIConnection:
    def __init__(self, base_url):
        self.base_url = base_url

    def clone(self):
        # Retorna uma cópia do objeto atual
        return copy.copy(self)

    def get(self, endpoint):
        print(f"[GET] {self.base_url}/{endpoint}")

# Protótipo base
prototype = APIConnection("https://api.exemplo.com")

# Criando clones a partir do protótipo
conn1 = prototype.clone()
conn2 = prototype.clone()

class UserService:
    def __init__(self, api_connection):
        self.api = api_connection

    def get_user(self, user_id):
        self.api.get(f"users/{user_id}")

# Uso
service = UserService(conn1)
service.get_user(42)


Desvantagens
Adicionar clone() traz complexidade desnecessária em linguagens modernas com construtores simples e coletores de lixo.
É útil apenas em contextos específicos, como jogos ou simulações complexas.

4. Dependency Injection (moderno)

Ideia
As dependências são passadas de fora para dentro da classe, em vez de criadas internamente.

Aplicação
Usado em frameworks modernos (Spring, .NET, FastAPI, NestJS) para reduzir acoplamento e facilitar testes.

class APIConnection:
    def __init__(self, base_url):
        self.base_url = base_url
        print(f"Criando conexão para {self.base_url}")

    def get(self, endpoint):
        print(f"[GET] {self.base_url}/{endpoint}")

class UserService:
    def __init__(self, api_connection):
        # O serviço recebe a dependência de fora
        self.api = api_connection

    def get_user(self, user_id):
        self.api.get(f"users/{user_id}")

# Injeção manual da dependência
api = APIConnection("https://api.exemplo.com")
user_service = UserService(api)
user_service.get_user(7)


Teste com Mock

# Classe mock simulando a API real
class MockAPI:
    def get(self, endpoint):
        print(f"[MOCK] Simulando requisição: {endpoint}")

# Injetando o mock
mock_api = MockAPI()
test_service = UserService(mock_api)
test_service.get_user(123)


Vantagens

Desacoplamento total entre as classes.

Facilidade de testes (é simples substituir dependências).

Reuso e flexibilidade: basta injetar outra implementação.

Código mais limpo e sustentável.

Conclusão

Os padrões criacionais do GoF foram essenciais para resolver problemas de instanciação nas décadas passadas.
No entanto, frameworks modernos tornaram essas soluções mais simples por meio da Injeção de Dependência, que substitui com eficiência a maioria dos casos de uso dos padrões clássicos.

A DI:

reduz o acoplamento entre as classes;

facilita manutenção e testes;

promove código limpo e modular, aberto para extensão e fechado para modificação.

Em resumo, a DI representa a evolução natural dos padrões criacionais para o desenvolvimento atual.
