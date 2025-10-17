# Pergunta
O livro GoF (1994) é clássico, mas 30 anos depois nem todos os 23 padrões continuam
relevantes. Alguns foram absorvidos por linguagens modernas, outros considerados
overengineering, e alguns praticamente caíram em desuso. Entre os padrões do GoF mais criticados
e menos usados hoje, temos:
Singleton

• Crítica: promove global state, dificulta testes, acoplamento forte.
• Status: amplamente desencorajado; substituído por Dependency Injection.

Abstract Factory
• Crítica: muita verbosidade, excesso de interfaces/classes só para criação de objetos.
• Status: em linguagens modernas (Java com DI/Spring, C# com IoC, Python dinâmico),
tornou-se raramente necessário.

Prototype
• Crítica: duplicação de objetos via clone() se mostrou pouco prática, especialmente em
linguagens com garbage collector e construtores ricos.
• Status: pouco usado fora de contextos muito específicos (ex.: jogos ou DSLs)

Pelo texto acima, vocês percebem que os padrões criacionais foram substituídos pela Injeção de
Dependência, disponível em frameworks modernos. Mostre, por meio de código, essa afirmação,
explicitando as vantagens da DI em relação aos padrões criacionais. 

# Resposta

````markdown

##  Cenário Proposto

O exemplo gira em torno de uma **conexão com uma API de usuários**.  
A classe `APIConnection` simula uma conexão com uma API (ex.: `https://api.exemplo.com`), e o serviço `UserService` utiliza essa conexão para buscar informações de usuários.

O mesmo cenário é implementado de **quatro formas diferentes**:
1. Singleton Pattern  
2. Factory Pattern  
3. Prototype Pattern  
4. Dependency Injection (moderno)

---

##  Singleton Pattern

###  Ideia
Garantir que apenas **uma instância** da classe exista no sistema.

###  Aplicação
Útil para recursos únicos (ex.: logs, configuração, conexão global).

### Exemplo em Python

```python
class APIConnection:
    _instance = None

    def __new__(cls, base_url):
        if cls._instance is None:
            print("Criando conexão única com a API...")
            cls._instance = super(APIConnection, cls).__new__(cls)
            cls._instance.base_url = base_url
        return cls._instance

    def get(self, endpoint):
        print(f"[GET] {self.base_url}/{endpoint}")

class UserService:
    def __init__(self):
        # forte acoplamento: depende diretamente do singleton
        self.api = APIConnection("https://api.exemplo.com")

    def get_user(self, user_id):
        self.api.get(f"users/{user_id}")

service1 = UserService()
service2 = UserService()

service1.get_user(1)
service2.get_user(2)
print(service1.api is service2.api)  # True → mesma instância
````

### Desvantagens

* Cria **estado global** → dificulta testes.
* Dificulta o uso de múltiplas conexões (ex.: ambientes diferentes).
* Aumenta o **acoplamento** entre classes.
* Rompe o princípio da *injeção de dependência*.

---

## Factory Pattern

###  Ideia

Encapsular a criação de objetos em uma “fábrica”, separando a lógica de construção da lógica de uso.

### Aplicação

Útil quando há **múltiplas variantes de objetos** que seguem a mesma interface.

### Exemplo em Python

```python
class APIConnection:
    def __init__(self, base_url):
        self.base_url = base_url
        print(f"Criando nova conexão para {self.base_url}")

    def get(self, endpoint):
        print(f"[GET] {self.base_url}/{endpoint}")

class APIConnectionFactory:
    @staticmethod
    def create_connection():
        return APIConnection("https://api.exemplo.com")

class UserService:
    def __init__(self):
        self.api = APIConnectionFactory.create_connection()

    def get_user(self, user_id):
        self.api.get(f"users/{user_id}")

service = UserService()
service.get_user(5)
```

### Desvantagens

* Código mais **verboso** e difícil de ler.
* A **fábrica ainda decide o tipo da conexão**, mantendo o acoplamento.
* Dificulta a substituição por *mocks* ou *stubs* em testes.

---

##  Prototype Pattern

### Ideia

Criar novos objetos clonando um protótipo existente em vez de instanciá-los do zero.

###  Aplicação

Útil quando a **criação de objetos é custosa** e o **clone** é mais rápido.

###  Exemplo em Python

```python
import copy

class APIConnection:
    def __init__(self, base_url):
        self.base_url = base_url

    def clone(self):
        return copy.copy(self)

    def get(self, endpoint):
        print(f"[GET] {self.base_url}/{endpoint}")

# Protótipo base
prototype = APIConnection("https://api.exemplo.com")

# Clonando
conn1 = prototype.clone()
conn2 = prototype.clone()

class UserService:
    def __init__(self, api_connection):
        self.api = api_connection

    def get_user(self, user_id):
        self.api.get(f"users/{user_id}")

service = UserService(conn1)
service.get_user(99)
```

### Desvantagens

* Pouco útil em linguagens modernas (como Python) com construtores simples.
* `clone()` adiciona complexidade desnecessária.
* Mais aplicável em contextos de **jogos**, **modelagem 3D** ou **DSLs**.

---

## Dependency Injection (moderno)

### Ideia

As dependências são **injetadas de fora** da classe, em vez de serem criadas dentro dela.

### Aplicação

Usado em frameworks modernos (Spring, .NET, NestJS, FastAPI) para **reduzir acoplamento** e **facilitar testes**.

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
        # dependência é injetada externamente
        self.api = api_connection

    def get_user(self, user_id):
        self.api.get(f"users/{user_id}")

# Injeção manual
api = APIConnection("https://api.exemplo.com")
user_service = UserService(api)

user_service.get_user(7)
```

### Teste com Mock

```python
class MockAPI:
    def get(self, endpoint):
        print(f"[MOCK] Simulando requisição: {endpoint}")

mock_api = MockAPI()
test_service = UserService(mock_api)
test_service.get_user(123)
```

### Vantagens

* **Desacoplamento total** entre classes.
* **Testabilidade:** fácil substituir dependências reais por *mocks*.
* **Reuso e extensibilidade:** basta injetar novas implementações.
* **Código mais limpo e sustentável**.
* Compatível com *IoC Containers* (ex.: FastAPI, Spring, etc).

---

## Comparativo Geral

| Padrão                   | Vantagens                                   | Desvantagens                                |
| ------------------------ | ------------------------------------------- | ------------------------------------------- |
| **Singleton**            | Uma instância única e global                | Dificulta testes, cria dependências ocultas |
| **Factory**              | Centraliza criação de objetos               | Verbosidade, acoplamento persiste           |
| **Prototype**            | Criação rápida de clones                    | Pouco útil em linguagens modernas           |
| **Dependency Injection** | Simplicidade, testabilidade e flexibilidade | Requer controle externo ou framework de DI  |

---

## Conclusão

Os **padrões criacionais do GoF** surgiram para resolver **problemas de instanciação e gerenciamento de dependências** em linguagens da década de 1990.

Com a evolução das linguagens e frameworks modernos, a **Injeção de Dependência (DI)** passou a **substituir esses padrões**, oferecendo:

* melhor desacoplamento entre módulos;
* maior facilidade de manutenção e testes;
* controle centralizado do ciclo de vida dos objetos.

 **Em resumo:**

> “Hoje, o Singleton, Factory e Prototype são soluções para problemas que a Injeção de Dependência já resolve de forma mais simples, segura e moderna.”

---
