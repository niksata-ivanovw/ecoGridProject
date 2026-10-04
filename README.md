# EcoGrid Simulator

A C# Windows Forms application for modeling, simulating, and optimizing power distribution across electrical grids.

## Overview

EcoGrid Simulator provides an interactive simulation environment for power distribution networks. It allows users to model power sources (generators, plants) and prioritized power consumers (residential zones, commercial hubs, hospitals) interconnected via transmission lines with defined line loss factors.

The system applies graph theory algorithms to determine optimal power distribution, detect network islands/disconnections, and manage loads dynamically.

## Key Features

- **Interactive Network Modeling:** Add, configure, and inspect grid nodes (Sources and Consumers) with custom capacities, priorities, and active states.
- **Power Flow Optimization:** Automated distribution algorithm that allocates available generation to consumers based on configurable priority tiers.
- **Graph Topology & Connectivity:** Disjoint-Set (Union-Find) algorithm to monitor partition states and line connectivity in real time.
- **Snapshots & History:** Integrated SQLite database to persist network topologies and track snapshot history for undo and audit operations.
- **Visual Grid Canvas:** Real-time visual canvas rendering transmission lines, energized substations, and overload conditions.

## Tech Stack

- **Language:** C# (.NET Framework 4.7.2)
- **GUI Framework:** Windows Forms (WinForms)
- **Database:** SQLite (`System.Data.SQLite`)
- **Architecture:** Layered design pattern (Algorithms, Forms, Models)

## Project Structure

```text
gridProject/
├── Algorithms/         # Graph manager, Union-Find logic, flow optimization
├── Forms/              # UI forms (MainForm, AddNodeForm, EditEdges)
├── Models/             # Domain models (Node, Edge, NetworkSnapshot)
├── gridProjectDB.db    # SQLite network database
└── gridProject.sln     # Visual Studio solution file
```

## Getting Started

### Prerequisites
- Visual Studio 2022 (or newer) with the **.NET desktop development** workload installed.

### Installation & Run
1. Clone the repository:
   ```bash
   git clone https://github.com/niksata-ivanovw/ecoGridProject.git
   ```
2. Open `gridProject/gridProject.sln` in Visual Studio.
3. Restore NuGet packages (`Tools` > `NuGet Package Manager` > `Manage NuGet Packages for Solution`).
4. Build and run the project (`F5` or `Ctrl + F5`).\n
