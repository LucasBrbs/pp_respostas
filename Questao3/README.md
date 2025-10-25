## Cenário Proposto

O exemplo gira em torno de uma **conexão com uma API de usuários**.  
A classe `APIConnection` simula uma conexão com uma API (ex.: `https://api.exemplo.com`), e o serviço `UserService` utiliza essa conexão para buscar informações de usuários.

O mesmo cenário é implementado de **quatro formas diferentes**:
1. Singleton Pattern  
2. Abstract Factory Pattern  
3. Prototype Pattern  
4. Dependency Injection (moderno)

---

## Singleton Pattern

### Ideia
Garantir que apenas **uma instância** da classe exista no sistema.

### Aplicação
Usado quando se quer controlar um recurso global, como logs ou configurações.

### Exemplo em Python

```python
class APIConnection:
    _instance = None

    def __new__(cls, base_url):
        # Se ainda não existe uma instância, cria uma
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
        # Aqui o serviço depende diretamente do Singleton
        self.api = APIConnection("https://api.exemplo.com")

    def get_user(self, user_id):
        self.api.get(f"users/{user_id}")

# Testando
service1 = UserService()
service2 = UserService()

service1.get_user(1)
service2.get_user(2)
print(service1.api is service2.api)  # True → é a mesma instância
```

### Desvantagens

* Cria um **estado global** difícil de controlar.
* Prejudica testes, pois não é fácil substituir a dependência.
* Aumenta o acoplamento entre as classes.

---

## Abstract Factory Pattern

### Ideia
Fornecer uma **interface para criar famílias de objetos relacionados**, sem especificar suas classes concretas.

### Aplicação
Usado quando há diferentes variações de produtos que seguem a mesma interface (ex.: conexões de API diferentes para ambientes distintos).

### Exemplo em Python

```python
# Interface base para conexões
class APIConnection:
    def get(self, endpoint):
        raise NotImplementedError

# Implementação concreta para o ambiente de produção
class ProductionAPIConnection(APIConnection):
    def __init__(self):
        self.base_url = "https://api.exemplo.com"
        print("Conexão de PRODUÇÃO criada")

    def get(self, endpoint):
        print(f"[GET] {self.base_url}/{endpoint}")

# Implementação concreta para o ambiente de testes
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

# Fábrica concreta para produção
class ProductionFactory(APIConnectionFactory):
    def create_connection(self):
        return ProductionAPIConnection()

# Fábrica concreta para teste
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

# Testando o uso das fábricas
factory = ProductionFactory()
service_prod = UserService(factory)
service_prod.get_user(5)

factory_teste = TestFactory()
service_teste = UserService(factory_teste)
service_teste.get_user(99)
```

### Desvantagens

* Muita **verbosidade**: várias classes e interfaces só para criar objetos.
* Mantém **acoplamento indireto** à fábrica concreta.
* Pouco necessário em linguagens modernas que já possuem injeção de dependências.

---

## Prototype Pattern

### Ideia
Criar novos objetos clonando um protótipo existente em vez de instanciá-los do zero.

### Aplicação
Usado quando a criação de um objeto é custosa, e clonar é mais rápido.

### Exemplo em Python

```python
import copy

class APIConnection:
    def __init__(self, base_url):
        self.base_url = base_url

    def clone(self):
        # Retorna uma cópia rasa do objeto atual
        return copy.copy(self)

    def get(self, endpoint):
        print(f"[GET] {self.base_url}/{endpoint}")

# Protótipo base
prototype = APIConnection("https://api.exemplo.com")

# Clonando novas conexões
conn1 = prototype.clone()
conn2 = prototype.clone()

class UserService:
    def __init__(self, api_connection):
        self.api = api_connection

    def get_user(self, user_id):
        self.api.get(f"users/{user_id}")

service = UserService(conn1)
service.get_user(42)
```

### Desvantagens

* `clone()` adiciona complexidade sem necessidade em muitos casos.
* Pouco útil em linguagens com construtores simples e coletores de lixo.
* Mais usado em contextos específicos, como jogos ou simulações.

---

## Dependency Injection (moderno)

### Ideia
As dependências são **injetadas de fora da classe**, em vez de criadas dentro dela.

### Aplicação
Usado em frameworks modernos (como Spring, .NET, NestJS ou FastAPI) para reduzir acoplamento e facilitar testes.

### Exemplo em Python

```python
class APIConnection:
    def __init__(self, base_url):
        self.base_url = base_url
        print(f"Criando conexão para {self.base_url}")

    def get(self, endpoint):
        print(f"[GET] {self.base_url}/{endpoint}")

class UserService:
    def __init__(self, api_connection):
        # Aqui o serviço recebe a dependência de fora
        self.api = api_connection

    def get_user(self, user_id):
        self.api.get(f"users/{user_id}")

# A injeção é feita de forma explícita
api = APIConnection("https://api.exemplo.com")
user_service = UserService(api)
user_service.get_user(7)
```

### Teste com Mock

```python
# Classe mock simulando a API real
class MockAPI:
    def get(self, endpoint):
        print(f"[MOCK] Simulando requisição: {endpoint}")

# Injetando o mock no serviço
mock_api = MockAPI()
test_service = UserService(mock_api)
test_service.get_user(123)
```

### Vantagens

* **Desacoplamento** total entre as classes.
* **Facilidade para testar**, pois é simples trocar a dependência real por um mock.
* **Reuso e flexibilidade**: basta injetar outra implementação.
* Código mais simples e de fácil manutenção.

---

## Comparativo Geral

| Padrão                   | Vantagens                                   | Desvantagens                                |
| ------------------------ | ------------------------------------------- | ------------------------------------------- |
| **Singleton**            | Uma instância única e global                | Dificulta testes e cria dependências ocultas |
| **Abstract Factory**     | Permite criar famílias de objetos           | Verboso e raramente necessário hoje          |
| **Prototype**            | Evita recriação de objetos custosos         | Pouco útil em linguagens modernas            |
| **Dependency Injection** | Simples, testável e flexível                 | Requer controle externo ou framework de DI   |

---

## Conclusão

Os **padrões criacionais do GoF** resolveram problemas de instanciação comuns nos anos 1990.  
Porém, em linguagens e frameworks atuais, a **Injeção de Dependência** passou a resolver esses problemas de forma mais limpa e direta.

A DI:

* reduz o acoplamento entre classes;
* facilita a manutenção e os testes;
* torna o código mais simples e sustentável.
