## Getting Started

- We can install rust using `rustup` tool.
- Rust compiler `rustc`

## Hello world

- Create a file main.rs with following code. main is the entry point

```
fn main() {
    println!("Hello, world!");
}
```
- To compile and run use command `rustc main.rs` and `./main` on linux or `main.exe` on windows

- We can give `main.exe` to anyone who does not have rust installed and they can still be able to run the program (on the same OS) - **ahead of time** compiled

## Cargo 

`cargo` is Build and package manager in this eco-system.
- To create a new project use command `cargo new project_name`
- To build the project use command `cargo build` inside the project folder
- To run the project use command `cargo run` inside the project folder
- To add dependencies, we can add in Cargo.toml file inside the project folder. Also we can do `cargo add <package>` to add a package to the toml file. 
- Cargo uses `crates.io` as the default package registry. Packages here are called crates. 

Some more cargo commands:
- `cargo check` - checks for errors without producing an executable
- `cargo test` - runs the tests
- `cargo doc`  - generates documentation of the project
- `cargo build --release` - To generate build in release mode with more optimizations for production run.
- `cargo clippy` - compiler suggestions for any idiomatic usages
- `cargo fmt` - To format codebase
- `cargo bench` - For benchmarking

```
TOML - Tom's Obvious Minimal Langauage