import csv

def get_data(): 
    """ Denne funktion importere filen 'tx_deathrow_full.csv'.

    >>> len(get_data())
    553

    """
    with open('tx_deathrow_full.csv') as csvfile:
        deathrow_reader = csv.DictReader(csvfile)
        for i in deathrow_reader:
            print(i)
    return deathrow_reader

def get_data(): 
    lst =[] 
    with open('tx_deathrow_full.csv') as csvfile:
        deathrow_reader = csv.DictReader(csvfile)
        for row in deathrow_reader:
            lst += [row]
    return lst

def to_metric(x):
    """ Denne function konverterer højden og vægten af hver dødsdømte fra imperial enheder til metriske enheder.

    >>> to_metric(get_data())[0]['Weight']
    98
    
    >>> to_metric(get_data())[0]['Height']
    185
    """
    metric_data = []
    for row in x:
        if row['Height']=='':
            height_cm="not found"
        else:
            [height_ft,height_in] = row['Height'].split("'")
            height_ft = int(height_ft)
            height_in = int(height_in.replace('"','').replace(' ',''))
            height_cm = round((height_ft * 12 + height_in) * 2.54)
        if row['Weight']: 
            weight_kg=round(float(row['Weight']) / 2.2046)
        metric_row = {
            'Height': height_cm,
            'Weight': weight_kg,
            'Execution': row['Execution'],
            'Date of Birth': row['Date of Birth'],
            'Date of Offence': row['Date of Offence'],
            'Highest Education Level': row['Highest Education Level'],
            'Last Name': row['Last Name'], 
            'First Name': row['First Name'],
            'TDCJ\nNumber': row['TDCJ\nNumber'],
            'Age at Execution': row['Age at Execution'], 
            'Date Received': row['Date Received'],
            'Race': row['Race'],
            'County': row['County'],
            'Eye Color': row['Eye Color'],
            'Native County': row['Native County'],
            'Native State': row['Native State'],
            'Last Statement': row['Last Statement']
        }
        metric_data.append(metric_row)
    return metric_data

def county_statistics(deathrow_data):
    """ Denne funktion laver en dictionary, hvor 'County' er en key og et heltal der beskriver antallet af dødsdømde født i den givne county er en value.
    
    >>> county_statistics(get_data())['Harris']
    128
    
    """
    newls = {}
    for i in deathrow_data:
        count = i['County']
        if count not in newls:
            newls[count]=0
        newls[count] += 1
    return newls     


def native_statistics(deathrow_data):
    """ Denne funktion laver en dictionary, hvor 'Native County' er en key og et heltal der beskriver antallet af dødsdømde født i den givne native county er en value. 
    
    >>> native_statistics(get_data())['Dallas']
    43
    
    """
    newls={}
    for i in deathrow_data:
        count = i['Native County']
        if count not in newls:
            newls[count]=0
        newls[count] += 1
    return newls   


def last_words_search(deathrow_data, words):
    """Dette er en søge funktion, der returnerer en dictionary med elementer bestående af fulde navn, alder og 
    final statement, hvis søge ordet eller ordene er indeholdt. 

    >>> last_words_search(get_data(),'Flødeskum')
    []

    >>> last_words_search(get_data(),"clown")
    [('Jeffrey Williams', '37', "You clown police. You gonna stop with all that killing all these kids. You're gonna stop killing innocent kids, murdering young kids. When I kill one or pop one, ya'll want to kill me. God has a plan for everything. You hear? I love everyone that loves me. I ain't got no love for anyone that don't love me.")]
    """
    newlst = []
    lst = words.split()
    for i in deathrow_data: 
        ls = i['Last Statement']
        for j in lst:
            if j in ls:
                x = (i['First Name']+" "+i['Last Name']),i['Age at Execution'],ls
                newlst.append(x)
    return newlst





