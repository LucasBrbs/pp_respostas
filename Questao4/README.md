# Comparação entre o Observer Clássico e suas aplicações modernas

O padrão **Observer** permite que um objeto (o *Subject*) notifique automaticamente uma lista de *observers* quando seu estado muda.  
Embora tenha sido criado há décadas, esse padrão é a base de muitos sistemas modernos — do Node.js ao React.

A seguir, são mostrados **três tecnologias modernas** que aplicam o mesmo conceito, comparadas ao **Observer clássico em Python**.

---

## 1) Observer Clássico — Python

Este exemplo implementa o padrão original do livro GoF.  
O `Subject` mantém uma lista de objetos observadores e envia notificações a todos sempre que ocorre uma mudança.

```python
# Implementação manual do padrão Observer em Python

class Subject:
    def __init__(self):
        # Lista de observadores interessados nos eventos
        self._observers = []

    def attach(self, observer):
        # Registra um novo observador
        self._observers.append(observer)

    def detach(self, observer):
        # Remove um observador
        self._observers.remove(observer)

    def notify(self, data):
        # Notifica todos os observadores com as informações do evento
        for observer in self._observers:
            observer.update(data)


# Interface genérica do observer
class Observer:
    def update(self, data):
        raise NotImplementedError


# Observador concreto que apenas exibe o evento
class PrintObserver(Observer):
    def __init__(self, name):
        self.name = name

    def update(self, data):
        print(f"[{self.name}] recebeu: {data}")


# Exemplo de uso
if __name__ == "__main__":
    subject = Subject()

    obs1 = PrintObserver("Log")
    obs2 = PrintObserver("Monitor")

    # Registrando os observadores
    subject.attach(obs1)
    subject.attach(obs2)

    # Notificando todos os observadores
    subject.notify({"evento": "login", "usuario": "lucas"})
```

**Resumo:**  
O `Subject` é quem controla os observadores e dispara notificações.  
Cada observador reage individualmente, implementando o método `update()`.

---

## 2) Node.js — EventEmitter

No Node.js, o padrão Observer já vem implementado na classe **EventEmitter**.  
Cada “evento” funciona como o `Subject`, e os “listeners” (funções registradas) atuam como observadores.

```javascript
// Node.js — Exemplo com EventEmitter
// Basta rodar: node observer_node.js

const EventEmitter = require('events');

// Cria um emissor de eventos (o "Subject")
class Canal extends EventEmitter {}

const canal = new Canal();

// Observadores (listeners)
function logListener(data) {
  console.log('[Log] Evento recebido:', data);
}

function analyticsListener(data) {
  console.log('[Analytics] Usuário registrado:', data.user);
}

// Registro dos observadores
canal.on('user_login', logListener);
canal.on('user_login', analyticsListener);

// Emissão de evento (notificação)
canal.emit('user_login', { user: 'lucas', hora: '08:00' });

// Removendo um listener e emitindo novamente
canal.removeListener('user_login', analyticsListener);
canal.emit('user_login', { user: 'maria', hora: '08:10' });
```

**Resumo:**  
- `on()` registra os observers.  
- `emit()` notifica todos os observers registrados.  
- `removeListener()` permite parar de observar.  

É a **implementação mais direta do Observer** em JavaScript.

---

## 3) RxJS (ReactiveX)

O **RxJS** (Reactive Extensions for JavaScript) leva o Observer a outro nível: trabalha com **fluxos contínuos de dados** (streams).  
O conceito de `Subject` e `subscribe()` substitui o modelo manual do GoF.

```javascript
// RxJS — Exemplo simples de Observer reativo
// Pode ser testado em Node.js ou navegador moderno

import { Subject } from 'rxjs';

// Cria o Subject (equivalente ao Subject do padrão clássico)
const subject = new Subject();

// Observadores se inscrevem no fluxo
subject.subscribe({
  next: (data) => console.log('[Observer A] recebeu:', data)
});

subject.subscribe({
  next: (data) => console.log('[Observer B] recebeu:', data)
});

// Emissão de eventos (notificação)
subject.next({ evento: 'login', usuario: 'lucas' });
subject.next({ evento: 'logout', usuario: 'maria' });
```

**Resumo:**  
- `Subject` é um emissor observável.  
- `subscribe()` registra os observadores.  
- `next()` envia os eventos a todos os inscritos.  

É o mesmo padrão Observer, só que voltado para **programação reativa** e **fluxos assíncronos**.

---

## 4) React Hooks — useEffect (UI Reativa)

O React aplica o Observer internamente: sempre que um **estado** muda, o componente é re-renderizado.  
O `useEffect` atua como o “observador” de variáveis declaradas como dependências.

```javascript
// React — Exemplo com useEffect
// Salvar como Contador.jsx e rodar em um projeto React

import React, { useState, useEffect } from 'react';

function Contador() {
  const [contador, setContador] = useState(0);

  // O React observa "contador" e executa o efeito quando ele muda
  useEffect(() => {
    console.log('Contador mudou para:', contador);
    // return opcional: executa limpeza antes do próximo efeito
    return () => console.log('Limpando efeito anterior');
  }, [contador]); // o array de dependências é o "Subject" observado

  return (
    <div style={{ fontFamily: 'Arial' }}>
      <p>Valor: {contador}</p>
      <button onClick={() => setContador(contador + 1)}>Aumentar</button>
      <button onClick={() => setContador(0)}>Zerar</button>
    </div>
  );
}

export default Contador;
```

**Resumo:**  
- O estado `contador` é o *subject*.  
- O código dentro do `useEffect` é o *observer*.  
- Quando o estado muda, o efeito é reexecutado — ou seja, o observer é notificado automaticamente.

---

## Conclusão Comparativa

Apesar das diferenças de sintaxe e contexto, todas as abordagens partem da **mesma ideia conceitual**:

| Tecnologia | Mecanismo do Subject | Registro de Observers | Ação de Notificação | Tipo de Reatividade |
|-------------|----------------------|------------------------|---------------------|----------------------|
| **Python (GoF)** | Classe `Subject` | `attach()` | `notify()` | Manual |
| **Node.js (EventEmitter)** | `EventEmitter` | `on()` | `emit()` | Eventos assíncronos |
| **RxJS (ReactiveX)** | `Subject` | `subscribe()` | `next()` | Fluxo reativo |
| **React (useEffect)** | Estado/Props | Array de dependências | Re-renderização + efeito | UI declarativa |

### Em resumo:
O que antes era apenas uma lista de objetos sendo notificados (GoF), hoje se tornou a base da **reatividade** em várias áreas:
- Em **Node.js**, serve para eventos e streams.
- Em **RxJS**, para dados assíncronos contínuos.
- Em **React**, para interfaces reativas.

O conceito central é o mesmo:  
**“Algo muda → quem está observando reage automaticamente.”**
