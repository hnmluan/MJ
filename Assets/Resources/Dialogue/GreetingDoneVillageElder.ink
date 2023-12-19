INCLUDE globals.ink

Task.Greeting16 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
Task.Greeting17 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
Task.Greeting18 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
Task.Greeting19 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
    + [Task.Greeting19.choice1]
    ~ rewardWeapon("Bow",1)
    -> main
    + [Task.Greeting19.choice2]
    ~ rewardWeapon("Lance",1)
    -> main
    
=== main ===
Task.Greeting28 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
~ switch2NextTask()
~ showTaskPanel()
Task.Greeting29 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
Task.Greeting30 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
~ guide()
Task.Greeting31 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
-> END

