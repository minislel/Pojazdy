# Vehicles class hierarchy
## College exercise, a simple class hierarchy for vehicles in C#.

### Description
This is a simple class hierarchy for vehicles in C#. 
The hierarchy includes a base class `AbstractVehicle` and many derived classes like `AmphibiousVehicle` and `Plane`. 
The `AbstractVehicle` class has many properties, like `Speed`, `State` (i.e, Moving/Stationary), it handles Acceleration and Deceleration, changing the Environment (i.e, Land, Water, Air), converting between speed units (i.e, km/h, m/s, knots), and a method to print the vehicle's state.
Interfaces and definitive classes implement more specific behaviors, like `IAirborne` and `Airplane`, `IWater` and `Motorboat`, etc.
