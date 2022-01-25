-- welche fische gibt es und wer hat diese schon gefangen
SELECT
	tfish.name, tcatch.fisher
FROM
	tfish
		LEFT JOIN
	tcatch ON tcatch.fish = tfish.id