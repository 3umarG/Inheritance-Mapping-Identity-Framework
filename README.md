# Mapping Strategy for Inheritance Relationship in .NET API 6 Application

## Overview

This repository contains a .NET API 6 application that demonstrates two different mapping strategies for handling inheritance relationships: TPH (Table Per Hierarchy) and TPT (Table Per Type). The aim of this project is to compare these two strategies in terms of storage efficiency, performance, and maintainability.

## Table of Contents

- [Introduction](#introduction)
- [Installation](#installation)
- [Mapping Strategies](#mapping-strategies)
- [Comparison](#comparison)
- [Performance Analysis](#performance-analysis)
- [ERDs](#erds)
- [References](#references)

## Introduction

In object-oriented programming, inheritance allows a class (subclass) to inherit properties and behaviors from another class (base class). When working with a database, mapping these inheritance relationships efficiently becomes important. This project explores two common mapping strategies: TPH (Table Per Hierarchy) and TPT (Table Per Type) in a .NET API 6 application.

TPH strategy involves storing all subclasses of a hierarchy in a single table, utilizing a discriminator column to differentiate between different types. On the other hand, TPT strategy uses a separate table for each subclass, linked to the base class table through foreign keys.

By comparing these strategies, we aim to understand the trade-offs between storage efficiency, performance, and ease of maintenance, helping developers make informed decisions when designing their data models.

## Installation

To run the project locally, follow these steps:

1. Clone the repository to your local machine.
2. Ensure you have .NET SDK 6 installed.
3. Restore the NuGet packages by running `dotnet restore` in the project's root directory.
4. Build the application using `dotnet build`.
5. Run the application with `dotnet run`.

## Mapping Strategies

### TPH (Table Per Hierarchy) Strategy

In TPH strategy, all subclasses of a hierarchy are stored in a single table. A discriminator column is used to differentiate between different entity types in the table. This approach simplifies the database schema but can lead to redundancy and less efficient storage, as all properties for all subclasses are stored in one table.

### TPT (Table Per Type) Strategy

In TPT strategy, each subclass has its own separate table, which is linked to the base class table through foreign keys. This approach allows for a more normalized database schema but can result in complex queries when fetching data involving multiple subclasses.

## Comparison

Let's compare the TPH and TPT strategies based on three key criteria:

### Storage Efficiency

- **TPH** : This strategy can lead to redundant storage, as all properties for all subclasses are stored in a single table. However, it may require fewer joins for certain queries.
- **TPT** : This strategy results in a more normalized schema, potentially reducing redundancy. Each subclass has its own table, leading to more efficient storage of properties unique to each subclass. However, queries may require more joins due to the separate tables.

### Performance

- **TPH** : With fewer joins required, certain queries may have better performance compared to TPT. However, queries involving complex inheritance hierarchies may perform slower due to the need for filtering based on the discriminator column.
- **TPT** : The normalized schema may lead to faster queries for certain scenarios. However, complex queries involving multiple subclasses may involve more joins and could impact performance.
  
### Cleaning and Maintenance

- **TPH** : The single-table approach makes schema updates straightforward. However, as the number of subclasses increases, the table can become cluttered, making maintenance challenging.
- **TPT** : The separated-table approach makes schema updates easier for individual subclasses. However, maintaining a large number of tables can be cumbersome.

### ERDs 
### TPH : Table Per Hierarchy
![TPH](https://github.com/OmarGomaaFCi/MappingStrategies/assets/90159439/76d68ca1-cffc-4bdb-920b-c98c882a9582)

### TPT : Table Per Type
![TPT](https://github.com/OmarGomaaFCi/MappingStrategies/assets/90159439/175e2f93-6770-494f-8a2f-b6a0a474d022)

## References
- [Inheritance Modelling by Microsoft .](https://learn.microsoft.com/en-us/ef/core/modeling/inheritance)
- [Performance of each Modelling by Microsoft .](https://learn.microsoft.com/en-us/ef/core/performance/modeling-for-performance#inheritance-mapping)
