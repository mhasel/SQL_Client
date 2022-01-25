-- wer hat schonmal einen XY gefangen

SELECT
	CONCAT(tfisher.name, ' ', tfisher.surname) AS 'NAME',
    tfish.name as 'FISH'
FROM
	tfish, tfisher, tcatch
WHERE tcatch.fish = tfish.id AND tcatch.fisher = tfisher.id  AND tfish.name = 'karp'
	