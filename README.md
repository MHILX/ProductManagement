# Product Management


## Components & Concepts of DDD (Domain Driven Design)
Domain-Driven Design (DDD) is a software development approach that focuses on modeling the domain according to the real-world business context.

### Entity: 
An object that is defined by its identity rather than its attributes. For example, a Customer entity with a unique identifier.

### Value Object:
An object that is defined by its attributes rather than its identity. 
For example, 
- A Money object with an amount and currency.
- An Address value object.

### Aggregate:
A cluster of associated objects that are treated as a single unit.

Each aggregate has a root entity known as the aggregate root, 
which is responsible for ensuring the consistency of changes being 
made within the aggregate.

For example, an Order aggregate that consists of OrderLine items.

### Repository:
A mechanism for encapsulating storage, retrieval, and search behavior 
which emulates a collection of objects.

### Domain Service:
An operation or a set of operations that do not naturally fit within 
the domain objects. Services are used to perform domain logic that 
doesn't belong to any specific entity or value object.

>**Domain Service vs Application Service:**
Domain Services focus on business logic and rules, while Application 
Services focus on orchestrating use cases and handling external 
interactions.

### Domain Event:
An event that represent a state change within the domain. For example, 
an OrderPlaced event that is raised when an order is placed.

### Domain Event Handler:
A component that handle domain event(s) and perform side-effects such as
sending notifications or updating external systems.

### Bounded Context:
A boundary within which a particular model is defined and applicable. 
It helps to delineate the scope of a particular domain model and its 
relationships with other models.

### Anti-Corruption Layer (ACL):
A layer that translates data and logic between different bounded 
contexts to prevent the spread of unwanted dependencies.

### Ubiquitous Language:
A language that is shared by all team members, including domain experts,
developers, and stakeholders. It helps to ensure that everyone has a 
common understanding of the domain concepts and terms.

### Context Map:
A visual representation of the relationships between bounded contexts
and their interactions.

---

## Clean Architecture
Clean Architecture is a software design philosophy that separates 
the concerns of the application into distinct layers. It aims to
create a flexible and maintainable codebase by enforcing a clear
separation of concerns.

###	Separation of Concerns: 
The system is divided into layers that each have distinct responsibilities.

### Dependency Rule: 
Dependencies should point inward. High-level policies should not depend on 
low-level details.
### Entities (Domain Model):
Represent the core business logic and rules independent of application concerns.
### Use Cases (Application Layer):
Orchestrate business rules to fulfill application-specific tasks. They act as 
an intermediary between the domain and interface layers.
### Interface Adapters:
Translate data between external systems (like databases, UIs, or APIs) and 
the use cases/domain entities.
### Frameworks and Drivers:
The outermost layer which includes UI, database, web frameworks, 
and other external components.


