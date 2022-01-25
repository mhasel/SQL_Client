#INSERT INTO tverfügbar (Verfügbar) VALUES ('bald wieder');

/*
UPDATE tverfügbar
SET Verfügbar = 'demnächst'
WHERE id = 5
*/

/*
DELETE FROM tverfügbar
WHERE id = 5
*/

/*
#Alle Kühlschränke, in welcher Kategorie sie gelistet und deren Verfügbarkeit
SELECT tprodukt.Bezeichnung AS Produkt, tkategorie.Bezeichnung AS Kategorie, tverfügbar.Verfügbar AS verfügbar
FROM tprodukt
JOIN tkategorie ON tprodukt.Kategorie = tkategorie.id
JOIN tverfügbar ON tprodukt.Verfügbar = tverfügbar.id
WHERE tprodukt.Bezeichnung = 'Kühlschrank'
ORDER BY tprodukt.Bezeichnung	
*/

/*
#Liste alle Kategorien auf und – so in einer Kategorie Produkte vorhanden sind – diese Produkte.

SELECT tkategorie.Bezeichnung AS Kategorie, tprodukt.Bezeichnung AS Produkt
FROM tkategorie
LEFT JOIN tprodukt ON tprodukt.Kategorie = tkategorie.id
ORDER BY tkategorie.Bezeichnung
*/

/*
#Liste alle Produkte, soweit vorhanden mit deren Verfügbarkeit auf
SELECT tprodukt.Bezeichnung, tverfügbar.Verfügbar
FROM tprodukt
LEFT JOIN tverfügbar ON tprodukt.Verfügbar = tverfügbar.id
ORDER BY tprodukt.Bezeichnung
*/

SELECT tprodukt.Bezeichnung AS Produkt, tverfügbar.Verfügbar 
FROM tprodukt
LEFT JOIN tverfügbar ON tprodukt.Verfügbar = tverfügbar.id
ORDER BY tprodukt.Bezeichnung