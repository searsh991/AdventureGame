# 📘 Battle System Refactor Plan

This document describes how to reorganize the battle logic into a dedicated **Battle class**, how to structure the main team-vs-team battle loop, how the 1v1 duel method works, and how to modernize your alive/dead checks using **properties** and **ternary operators**.

Use this as a reference while rebuilding the battle system.

---

## 🧩 1. Goals of the Refactor

The current battle logic is spread across `Program` and multiple methods.  
This refactor aims to:

- Move **all battle-related logic** into a separate `Battle` class  
- Cleanly separate responsibilities:
  - Program = setup (teams, menus)
  - Battle class = all fighting logic
- Use **property-based alive checks** instead of manual flags
- Use cleaner syntax (ternary, expression-bodied properties)
- Simplify the team-vs-team battle loop so it’s predictable and maintainable

---

## 🛡️ 2. New `Battle` Class Structure

Create a class called `Battle` or `BattleManager`.

It should contain:

### **Fields**
- `Fighter[] myTeam`
- `Fighter[] enemyTeam`
- A shared `Random` instance

### **Methods**
1. **`RunBattle()`**  
   - The main team-vs-team loop.  
   - Continues until one team has **no alive fighters**.

2. **`InitiateBattle(Fighter a, Fighter b)`**  
   - Decides who attacks first (speed check).  
   - Calls the `Fight()` method.

3. **`Fight(Fighter attacker, Fighter defender)`**  
   - Runs the full 1v1 duel.  
   - Alternating hits until one fighter is dead.  
   - Returns the fighter who survives.

4. **`GetRandomAliveFighter(Fighter[] team)`**  
   - Returns one randomly chosen fighter whose health > 0.

5. **`TeamHasAlive(Fighter[] team)`**  
   - Returns true if **any** fighter in the team is alive.

---

## 🔁 3. Team Battle Loop (Inside `RunBattle()`)

Logic of the main battle:

1. Loop **while both teams still have alive fighters**.
2. Pick one fighter from each team using `GetRandomAliveFighter`.
3. Print their names/stats (optional).
4. Decide attack order with `InitiateBattle`.
5. Run the 1v1 duel in `Fight`.
6. One fighter dies → the winner returns alive.
7. Loop continues to next round.

**Battle ends when one team has zero alive fighters.**

---

## ⚔️ 4. 1v1 Duel Logic (Inside `Fight()`)

The duel method handles only two fighters:

1. Compare their speed.  
2. If tied, pick randomly.  
3. Attacker hits defender → defender loses HP.  
4. If defender dies, attacker wins.  
5. Otherwise, swap roles and repeat.

Always return the **winner** of the duel.

No extra booleans are needed — health alone controls life and death.

---

## ❤️ 5. Converting Alive Checks to Properties

Instead of manually updating `fighter.isAlive` in multiple places, use property-based logic.

In `Fighter` class:

```csharp
public bool IsAlive => hp > 0;
```

This:

- Is a **read-only property**
- Automatically returns true/false based on `hp`
- Eliminates the chance of desync between `hp` and `isAlive`
- Makes code cleaner:

```csharp
if (fighter.IsAlive) { ... }
```

You can also add other computed properties:

```csharp
public bool IsDead => !IsAlive;
public bool IsFast => speed > 10;
```

---

## 🎭 6. Ternary Operator (`? :`) Explanation

The **ternary operator** is a shorter way to write an if/else that returns a value.

Pattern:

```csharp
condition ? valueIfTrue : valueIfFalse
```

### Example: picking the loser

```csharp
Fighter loser = winner == fighterA ? fighterB : fighterA;
```

Reads as:

> If winner is fighterA → loser is fighterB  
> Otherwise → loser is fighterA

### Example: status text

```csharp
string status = fighter.IsAlive ? "Alive" : "Dead";
```

### Example: picking the faster fighter

```csharp
Fighter first = fighterA.speed > fighterB.speed ? fighterA : fighterB;
```

Ternary expressions make battle logic shorter and easier to understand.

---

## 📝 7. What to Change in Your Project

### ✔ Create new `Battle` class  
Move these methods into it:
- `GeneralFight` (rename to `RunBattle`)
- `InitiateBattle`
- `Fight`
- `IsAlive(Fighter[] team)`
- `getPlayer` (rename to `GetRandomAliveFighter`)

### ✔ Replace `fighter.isAlive` with `fighter.IsAlive`

### ✔ Replace many if/else blocks with ternary expressions where appropriate

### ✔ Update `Program.Main`:
- Build teams  
- Create a `Battle` object  
- Call `battle.RunBattle()`  

### ✔ Remove unnecessary methods:
- `NextPlayerTeam`
- `PlayerDead`  
(They become obsolete with the new loop.)

---

## 🏁 Final Thoughts

Once this refactor is done, your battle logic becomes:

- Cleaner  
- Smaller  
- Easier to debug  
- Ready for more advanced features  
- Easy to reuse in a future menu or gameplay system  

