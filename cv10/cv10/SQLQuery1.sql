SELECT 
    s.[ID_Studenta],
    s.[Jmeno],
    s.[Prijmeni],
    z.[Zkratka],
    p.[Nazev]
FROM 
    [dbo].[Student] s
LEFT JOIN [dbo].[Zapis] z ON s.[ID_Studenta] = z.[ID_Studenta]
LEFT JOIN [dbo].[Predmet] p ON z.[Zkratka] = p.[Zkratka];
GO

SELECT 
    [Prijmeni],
    COUNT(*) AS [Pocet]
FROM 
    [dbo].[Student]
GROUP BY 
    [Prijmeni]
ORDER BY 
    [Pocet] DESC;
GO

SELECT 
    p.[Zkratka],
    p.[Nazev],
    COUNT(z.[ID_Studenta]) AS [PocetStudentu]
FROM 
    [dbo].[Predmet] p
LEFT JOIN [dbo].[Zapis] z ON p.[Zkratka] = z.[Zkratka]
GROUP BY 
    p.[Zkratka], p.[Nazev]
HAVING 
    COUNT(z.[ID_Studenta]) < 3;
GO

SELECT 
    p.[Zkratka],
    p.[Nazev],
    MIN(h.[Hodnoceni]) AS [Nejlepsi],
    MAX(h.[Hodnoceni]) AS [Nejhorsi],
    AVG(CAST(h.[Hodnoceni] AS FLOAT)) AS [Prumer],
    COUNT(*) AS [PocetHodnocenych]
FROM 
    [dbo].[Predmet] p
JOIN [dbo].[Hodnoceni] h ON p.[Zkratka] = h.[Zkratka]
GROUP BY 
    p.[Zkratka], p.[Nazev];
GO