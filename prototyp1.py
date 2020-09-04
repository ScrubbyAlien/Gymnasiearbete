import math

totalMembers = int(input("Hur många elever? "))
intitiallyInfected = int(input("Hur många är sjuka? "))
infectionRate = float(input("Smittspridningsfaktor? "))
daysTillSymptomFree = int(input("Hur många dagar tills man blir symptomfri? "))
healthy = totalMembers - intitiallyInfected
infected = intitiallyInfected
removed = 0


print("\nTotal Members: " + str(totalMembers) + "\nHealthy: " + str(healthy) +
      "\nInfected: " + str(infected) + "\nInfectionRate: " + str(infectionRate) +
      "\nDays until free of symptoms: " + str(daysTillSymptomFree))
input()

infectedPerDay = [intitiallyInfected]
infectedYesterday = intitiallyInfected
day = 0


while(0.5 <= infected and removed < totalMembers - 0.5):
    day += 1

    if(healthy > 0):
        infectedToday = infected * infectionRate - infected
    elif(healthy - (infected * infectionRate - infected) < 0):
        infectedToday = healthy
    infectedPerDay.insert(day, infectedToday)

    if(day - daysTillSymptomFree >= 0):
        if(removed + infectedPerDay[day - daysTillSymptomFree] < totalMembers):
            removed += infectedPerDay[day - daysTillSymptomFree]
            infected -= infectedPerDay[day - daysTillSymptomFree]
        else:
            removed = totalMembers
            infected = 0

    if(healthy - infectedToday > 0):
        infected += infectedToday
        healthy -= infectedToday
    else:
        infected += healthy
        healthy = 0

    print("Day: " + str(round(day)) + "\nHealthy: " + str(round(healthy)) + "\nInfected: "
          + str(round(infected)) + "\nRemoved: " +
          str(round(removed)) + "\nInfected Today: "
          + str(round(infectedPerDay[day])))
    input()
