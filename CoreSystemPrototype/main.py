import time

if __name__ == '__main__':

    normalChickens = [1]
    hybridChickens = []
    alienChickens = []
    chickens = [normalChickens, hybridChickens, alienChickens]

    hybridChickensInitial = 1
    alienChickensInitial = 1

    dna = 0
    cash = 0

    breederInitial = 1
    breederCount = 0

    while dna <= 8000000000:

        time.sleep(1)
        totalChickens = len(chickens[0]) + len(chickens[1]) + len(chickens[2])

        if dna >= 10 ** totalChickens:
            normalChickens.append(1)
            totalChickens = len(chickens[0]) + len(chickens[1]) + len(chickens[2])
            print("Normal: " + str(len(chickens[0])) + ", Hybrid: " + str(len(chickens[1])) + " , Alien: " + str(len(chickens[2])))

        if cash >= 100 ** breederInitial:
            cash = cash - (100 ** breederInitial)
            breederInitial = breederInitial + 1
            breederCount = breederCount + 1
            print("Breeder Count: " + str(breederCount) + ", Cash: " + str(cash))

        if cash >= 100 ** hybridChickensInitial and len(chickens[0]) >= 1:
            cash = cash - (100 ** hybridChickensInitial)
            hybridChickensInitial = hybridChickensInitial + 1
            normalChickens.remove(1)
            hybridChickens.append(5)
            totalChickens = len(chickens[0]) + len(chickens[1]) + len(chickens[2])
            print("Normal: " + str(len(chickens[0])) + ", Hybrid: " + str(len(chickens[1])) + " , Alien: " + str(len(chickens[2])))

        if cash >= 1000 ** alienChickensInitial and len(chickens[1]) >= 1:
            cash = cash - (1000 ** alienChickensInitial)
            alienChickensInitial = alienChickensInitial + 1
            hybridChickens.remove(5)
            alienChickens.append(10)
            totalChickens = len(chickens[0]) + len(chickens[1]) + len(chickens[2])
            print("Normal: " + str(len(chickens[0])) + ", Hybrid: " + str(len(chickens[1])) + " , Alien: " + str(len(chickens[2])))

        growth = (len(chickens[0]) * 1) + (len(chickens[1]) * 5) + (len(chickens[2]) * 10)

        cash = cash + growth
        dna = dna + growth
        print("DNA: " + str(dna) + ", Cash: " + str(cash))

