# DesignPatterns

Short examples of several design patterns with written in C#.

## Purpose

The goal of this repository is to provide a meaningful implementation example of
each pattern in order to help the reader to grasp the underlying intention
behind them.

> Thread safety, error handling, etc. are not a concern in those and are
> considered as implementation details.

If you would like to go deeper, [Raw Coding](https://www.youtube.com/watch?v=xN7EFHU_rXA&list=PLOeFnOV9YBa4ary9fvCULLn7ohNKR6Ees)
is doing an excellent work with its video tutorials. If you prefer a written
explanation, [TutorialsPoint](https://www.tutorialspoint.com/design_pattern/)
comes with a great number of examples (in Java) and
[Refactoring Guru](https://refactoring.guru/design-patterns/catalog) with a more
language-agnostic approach, detailing the heart of the problem.

## Content

Each implemented pattern can be found in the folder associated to its category:

- 🏃‍♀️ [Behavioral patterns](./Behavioral)
  - [Chain of responsibility](./Behavioral/ChainOfResponsibility.cs)
  - [Command](./Behavioral/Command.cs)
  - [Iterator](./Behavioral/Iterator.cs)
  - [Mediator](./Behavioral/Mediator.cs)
  - [Observer](./Behavioral/Observer.cs)
  - [State](./Behavioral/State.cs)
  - [Strategy](./Behavioral/Strategy.cs)
- 🏗️ [Creational patterns](./Creational)
  - [Abstract factory](./Creational/AbstractFactory.cs)
  - [Builder](./Creational/Builder.cs)
  - [Factory method](./Creational/FactoryMethod.cs)
  - [Prototype](./Creational/Prototype.cs)
  - [Singleton](./Creational/Singleton.cs)
- 🧱 [Structural patterns](./Structural)
  - [Adapter](./Structural/Adapter.cs)
  - [Flyweight](./Structural/Flyweight.cs)

> The `.Dump()` method is part of [LINQPad](https://www.linqpad.net/), check it
> out if you want to run those examples as is

## Contribution

Several patterns are still missing. If you would like to see a new one, please
[open an issue](https://github.com/pBouillon/DesignPatterns/issues/new) with its
name and category !
