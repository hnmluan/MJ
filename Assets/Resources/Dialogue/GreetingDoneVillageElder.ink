INCLUDE globals.ink

Task.Greeting16 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
Task.Greeting17 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
Task.Greeting18 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
Task.Greeting19 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
    + [Task.Greeting19.choice1]
    ~ rewardWeapon("Bow",1)
    + [Task.Greeting19.choice2]
    ~ rewardWeapon("Lance",1)
Task.Greeting28 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
Task.Greeting29 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
Task.Greeting30 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
Task.Greeting31 #layout:left #speaker:VillageElder #audio:animal_crossing_mid #portrait:village_elder
~ guide()
~ switch2NextTask()
