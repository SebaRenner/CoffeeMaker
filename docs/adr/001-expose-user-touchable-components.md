# ADR 001: Expose user-touchable components, hide machine operations

## Status
Accepted

## Context
`CoffeeMachine` composes several parts and holds all the logic. Callers need a way to act on it (press buttons, refill water and beans). I considered two options: exposing the components, or adding forwarding methods on the machine (`PressEspressoButton()`, `FillWaterTank()`, ...). Forwarding keeps everything private but needs one pass-through method per user action and hides the parts I modeled.

## Decision
`CoffeeMachine` exposes the parts a user physically touches (`ControlPanel`, `WaterTank`, `BeanHopper`, `GroundsContainer`) as public read-only properties. Callers act on the machine through these components and their public methods, for example `machine.WaterTank.FillToMax()` or `machine.ControlPanel.EspressoButton.Press()`. The machine does not add forwarding methods for them.

## Consequences
1. **Public methods on a component are the user's actions.** Anything public on an exposed component is reachable by every caller, so it must be something a person could do at a real machine (refill, empty, press).
2. **Machine-only operations must be `internal`.** Operations the machine performs on its parts, such as `WaterTank.Drain` and `BeanHopper.Remove`, are `internal` so callers cannot invoke them. `CoffeeMachine`'s own actions (`TogglePower`, `TurnOn`, `TurnOff`, `Brew`) stay `private` and are only reachable through the control panel.