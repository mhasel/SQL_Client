-- wer hat wann was gefangen
SELECT
	tfish.name as 'FISH',
    CONCAT(tfisher.name, ' ', tfisher.surname) AS 'NAME',
    tcatch.date as 'DATE'
FROM
	tfish, tfisher, tcatch
WHERE
	tcatch.fisher = tfisher.id AND tcatch.fish = tfish.id

