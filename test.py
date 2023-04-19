import pandas as pd
import psycopg2 as psy


#psql -U postgres -d test

co = None

var = []

try:
    
    co = psy.connect(host="localhost",user="postgres",database='test',password="14010")
    
    var =  pd.read_sql('SELECT id FROM utilisateur where addr=\'bapt.14@hotmail.com\'',con=co)

except(Exception,psy.DatabaseError) as error:
    print("Error While Connecting to DB",error)
        
finally:
    if co is not None:
        co.close()
        
print(var)