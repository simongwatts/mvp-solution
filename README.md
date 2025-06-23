# mvp-solution
## MVP Framework (Model-View-Presenter) with Passive View & SOLID Principles
A cross-platform, reusable framework for building decoupled, testable applications in **C#** (WinForms, Blazor WASM) and **TypeScript** (Web). Implements the Passive View variant of the MVP pattern with strict SOLID principles.
### TypeScript Step-by-Step Workflow
#### Build Core Library

cd mvp-core

npm install

npm run build  # Generates dist/ with type declarations

#### Link Core Library

cd mvp-core

npm link  # Makes mvp-core available globally

#### Link in Counter Example

cd counter-example

npm link mvp-core  # Uses the linked core library

npm install  # Install other dependencies

#### Start Dev Server

cd counter-example

npx webpack serve --open  # Auto-opens browser
