## Questão 4 – Comparação entre o Observer Clássico e suas Aplicações Modernas

O padrão Observer permite que um objeto (o Subject) notifique automaticamente uma lista de observers quando seu estado muda.
Embora tenha sido criado há décadas, ele serve de base para diversos sistemas modernos — do Node.js ao React.

A seguir, são apresentados o padrão clássico e três tecnologias que aplicam a mesma ideia.

1) Observer Clássico – Python

Este exemplo implementa o padrão original descrito no livro GoF.
O Subject mantém uma lista de observadores e os notifica sempre que ocorre uma mudança.

# Implementação manual do padrão Observer em Python
```csharp
class Subject:
    def __init__(self):
        # Lista de observadores interessados nos eventos
        self._observers = []

    def attach(self, observer):
        # Registra um novo observador
        self._observers.append(observer)

    def detach(self, observer):
        # Remove um observador existente
        self._observers.remove(observer)

    def notify(self, data):
        # Notifica todos os observadores com as informações do evento
        for observer in self._observers:
            observer.update(data)

# Interface genérica do observer
class Observer:
    def update(self, data):
        raise NotImplementedError

# Observador concreto que apenas exibe o evento recebido
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

    subject.attach(obs1)
    subject.attach(obs2)

    subject.notify({"evento": "login", "usuario": "lucas"})
```

Resumo:
O Subject controla os observadores e dispara notificações.
Cada Observer reage individualmente, implementando o método update().

2) Node.js – EventEmitter

Em Node.js, o padrão Observer já vem implementado na classe EventEmitter.
Cada evento é um Subject, e os listeners são os observadores.
```csharp
// Node.js — Exemplo com EventEmitter
const EventEmitter = require('events');

// O emissor de eventos funciona como o "Subject"
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

// Removendo um listener
canal.removeListener('user_login', analyticsListener);
canal.emit('user_login', { user: 'maria', hora: '08:10' });
```

Resumo:

on() registra os observadores.

emit() notifica todos os registrados.

removeListener() cancela a observação.
É uma implementação direta do padrão Observer em JavaScript.

3) RxJS (ReactiveX)

O RxJS expande o conceito de Observer para trabalhar com fluxos contínuos de dados (streams).
Aqui, Subject e subscribe() substituem o modelo manual do GoF.
```csharp
// RxJS — Exemplo simples de Observer reativo
import { Subject } from 'rxjs';

// O Subject atua como emissor e observável ao mesmo tempo
const subject = new Subject();

// Observadores se inscrevem no fluxo
subject.subscribe({
  next: (data) => console.log('[Observer A] recebeu:', data)
});

subject.subscribe({
  next: (data) => console.log('[Observer B] recebeu:', data)
});

// Envio de eventos (notificação)
subject.next({ evento: 'login', usuario: 'lucas' });
subject.next({ evento: 'logout', usuario: 'maria' });
```

Resumo:

Subject é o emissor observado.

subscribe() registra observadores.

next() envia notificações a todos.
O mesmo padrão Observer aplicado em programação reativa e assíncrona.

4) React Hooks – useEffect (UI Reativa)

O React aplica o Observer internamente: quando um estado muda, o componente é re-renderizado.
O useEffect atua como observador de variáveis declaradas como dependências.
```csharp
// React — Exemplo com useEffect
import React, { useState, useEffect } from 'react';

function Contador() {
  const [contador, setContador] = useState(0);

  // O React observa "contador" e executa este efeito sempre que ele muda
  useEffect(() => {
    console.log('Contador mudou para:', contador);
    return () => console.log('Limpando efeito anterior');
  }, [contador]); // o array de dependências é o "Subject"

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

Resumo:

O estado (contador) é o Subject.

O código dentro do useEffect é o Observer.

Quando o estado muda, o efeito é reexecutado, notificando o observador.

Conclusão Comparativa
Tecnologia	Mecanismo do Subject	Registro de Observers	Ação de Notificação	Tipo de Reatividade
Python (GoF)	Classe Subject	attach()	notify()	Manual
Node.js (EventEmitter)	EventEmitter	on()	emit()	Eventos assíncronos
RxJS (ReactiveX)	Subject	subscribe()	next()	Fluxos reativos
React (useEffect)	Estado / Props	Array de dependências	Re-renderização e efeito	UI declarativa

Síntese:
O padrão Observer evoluiu de uma simples lista de notificações (GoF) para a base da reatividade moderna:

Em Node.js, gerencia eventos e streams.

Em RxJS, controla fluxos assíncronos contínuos.

Em React, dirige a atualização automática de interfaces.

Mesmo com diferentes contextos, o princípio permanece o mesmo:
um objeto muda de estado e outros reagem automaticamente a essa mudança.
