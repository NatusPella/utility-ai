# Utility AI
Open source utility AI system for Unity3D

## Setup

1. Add a singular ``Manager`` component to a scene
2. Add an ``Entity`` for each unit that should have AI control
3. Give each ``Entity`` a ``Profile``
4. Tag special objects in the scene using the ``Tag`` component 

## Flow

An entity selects the best action to take based on the inputs that it has and the weights that different groups of actions have

## Extend

To extend the capabilities you may (easily) create your own classes that derive from ``Input`` or ``Action``
