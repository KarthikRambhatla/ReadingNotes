[Repo link](https://github.com/PacktPublishing/LLM-Engineers-Handbook)

Let's explore the tools we will use to achieve this project.
- [Python Ecosystem](#1-python-ecosystem-and-project-installation)
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

A dependency manager allows you to specify, install, update and manage external libraries or packages that a project relies on.

For example, this is a simple Poetry requirements file that uses Python 3.11 and the requests and numpy Python packages.

```
[tool.poetry.dependencies]
python = "^3.11"
requests = "^2.25.1"
numpy = "^1.19.5"

[build-system]
requires = ["poetry-core]
build-backend = "poetry.core.masonry.api"
```

By using poetry we can pin the corect versions of deps in project. By default, it saves all its requirements in `pyproject.toml` files , which are stored at root of repo.

Another advantage is it creates a new python virtual env which it installs the specified Python version and requirements. A Virtual env allows you to isolate deps from global ones and other projects. -> No version clashes


-> clone repo and run the following command
`poetry install --without aws`

This command picksup all deps as per `pyproject.toml` and `poetry.lock` file. 
After installing poetry, you can activate by running `poetry shell` or prefixing commands with `poetry run <command>`

* `pyproject.toml` specifies a range for the deps version. `poetry.lock` file records exact version. By locking deps and sub deps, all installations of project use same versions and this consistency reduces likelihood of "works on my machine" issues.

Other tools: Venv, Conda for creating virtual envs, they lack deps management option. You need to use Pythons default `requirements.txt` file, that are less powerful that lock files. Another option is `pipenv` but it is a slower. `uv` is a blazingly fast alternative potential to replace poetry built in rust.

#### Poe the Poet: task execution tool

`Poe the Poet` is a plugin on top of petry to manage and execute all CLI commands required to interact with project. You can define and run tasks within the poject - simplifies automation, script execution.

Other options - `Makefile` `Invoke`, `Shell Scripts`. 
But Poe the poet eleiminates the need to write separte make files, makes elegant way to manage tasks same config as poetry already uses for deps.

we can define the tasks in `pyproject.toml` file

```
[tool.poe.tasks]
test = "pytest"
format = "black ."
start = "python main.py"
```

Then we can run these tasks like `poetry poe test`, `poetry poe format`, `poetry poe start`

To install Poe the poet as plugin: `poetry self add 'poethepoet[poetry_plugin]'`

* having a tool as a facade over all the CLi commands is necessary to run the app. simplifies app complexity, enhances collaboration acting as out-of-the-box docs.

## 2. MLOps and LLMOps tooling

1. [Model Registry](#21-hugging-face-model-registry)
2. [Orchestrator, artifacts and metadata](#22-zenml-orchestrator-artifacts-and-metadata)
3. [Experiment Tracket]()
4. [Prompt Monitoring]()
5. [Databases for storing unstructured and vector data]()
6. [AWS SageMaker]()

To start in this repo. Have `docker` installed and fill `.env` file with all the creds needed, then run `poetry poe local-infrastructure-up` to locally spin up ZenML, MongoDB and Qdrant databases.

## 2.1 Hugging Face: Model Registry

A model registry is a centralized repo that manages ML models throughout their lifecycle. It stores models along with their metadata, version history, and performance metrics - single source of truth for models. 

In MLOps, model registry is crucial for tracking, sharng, and documentiing model versions, facilitating team collaboration. It integrates with CI/CD pipelines.

using Hugging Face, we can easily integrate model with all frameworks around LLMs ecosystem - Unsloth for fine-tuning and SageMaker for inference.

All other ML tools also provide their ownl model registries. Hugging Face provides easy shareability and integration throught Open source.

## 2.2 ZenML: Orchestrator, Artifacts and Metadata

Bridges ML <-> MLOps. offers features that make pipline traceability, reproducibility, deployment and maintainability easier. 

It is designed to create reproducible workflows in machine learning. Helps transitioning from exploratory research in Jupyter notebooks to a production-ready ML environment.

It tackles production-based replication issues, such as versioning difficulties, ,reproducing experiments, organizing complex ML workflows, bridging training and deployment, tracking metadata.

ZenML main features are otchestrating ML pipeline, storing and versioning piplines as outputs, attaching metadata to artifacts for better observability.

`stack` - A ZenML stack will enable you to connect ZenML to different cloud services. 
Compute engine can be AWS SageMaker, Remote Storage can be AWS S3 or Azure Blob, Container registry can be AWS ECR or Docker registry.

ZenML acts as a glue that brings all infra and tools in one place with its `stack` feature. No Vendor lock. Abstracts away implementation of Python code from infra it runs on.

So when we write LLM Twin, python code does not contain S3/ECR particularities. ZenML takes care of them.

Local version comes as a python package that we can install with poetry. we will also use their cloud serverless option to deploy the pipeline to AWS.

### Orchestrator

Automates, schedules and coordinates all ML pipelines. It ensures that each pipeline - data ingestion, preprocessing, and model training and deployment executes in the correct order and handles dependencies effeciently.

It makes resource utilization optimum, hanles failures gracefully, enhances scalability, making complex pipelines reliable and easier to manage

ZenML works with **pipelines** and **steps**. A pipline is a high level object that contains multiple steps. A function becomes a ZenML pipeline by being decorated with `@pipeline` and a step when decorated with `@step`. This is a standard pattern when using orchestrators: a high level function often called pipeline that calls multiple units/steps/tasks.

