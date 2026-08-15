[Repo link](https://github.com/PacktPublishing/LLM-Engineers-Handbook)

Let's explore the tools we will use to achieve this project.
- Python ecosystem
- MLOps and LLMOps tools
  - Model Registry
  - LLM Evaluati

## 1. Python ecosystem and project installation

Any python project needs 3 things
- Python interpreter
- dependency management
- task execution tool

To use the exact python version a project uses , we use python *version management tool* - `pyenv`. It lets you manage multiple versions for projects instead of installing a global version.

- install a particular python version  `pyenv install 3.11.8`
- list all versions  `pyenv versions`
- You can make this version the default setting global `pyenv global 3.11.8`
- inside the cloned repo, you can use `pyenv local 3.11.8`. This will create a .python-version local file with that pyenv will always know which version to use inside that folder

### Poetry: dependency and virtual env management



