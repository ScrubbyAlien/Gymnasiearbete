import math

totalMembers = int(input("Hur många elever? "))
intitiallyInfected = int(input("Hur många är sjuka? "))
infectionRate = float(input("Smittspridningsfaktor? "))
healthy = totalMembers - intitiallyInfected
infected = intitiallyInfected
removed = 0


print("Total Members: " + str(totalMembers) + "\nHealthy: " + str(healthy) +
      "\nInfected: " + str(infected) + "\nRemoved: " + str(removed) + "\n")

infectedPerDay = [intitiallyInfected]
infectedDayBefore = intitiallyInfected
day = 0

while(removed < totalMembers):
    day += 1

    if(infected * infectionRate < totalMembers):
        infected = infected * infectionRate
    else:
        infected = totalMembers

    infectedPerDay.append(round(infected) - round(infectedDayBefore))
    infectedDayBefore = infected

    healthy = totalMembers - infected
    if(day - 7 >= 0):
        removed += infectedPerDay[day - 7]

    stillInfected = round(infected) - round(removed)

    print("Day: " + str(day) + "\nHealthy: " + str(round(healthy)) + "\nInfected: " +
          str(round(infected)) + "\nStill Infected: " + str(stillInfected) + "\nRemoved: " + str(round(removed)) +
          "\nInfected Today: " + str(round(infectedPerDay[day])))
    input()
