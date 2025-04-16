-- Vložení studentů
INSERT INTO [dbo].[Student] VALUES
(1, 'Jan', 'Novák', '2001-05-12'),
(2, 'Petr', 'Svoboda', '2000-08-20'),
(3, 'Eva', 'Nováková', '2002-01-15'),
(4, 'Lucie', 'Novák', '2001-09-25');
GO

-- Vložení předmětů
INSERT INTO [dbo].[Predmet] VALUES
('MAT', 'Matematika'),
('PRG', 'Programování'),
('FYZ', 'Fyzika');
GO

-- Vložení zápisů studentů do předmětů
INSERT INTO [dbo].[Zapis] VALUES
(1, 'MAT'),
(1, 'PRG'),
(2, 'MAT'),
(3, 'PRG'),
(4, 'FYZ'),
(4, 'MAT');
GO

-- Vložení hodnocení
INSERT INTO [dbo].[Hodnoceni] VALUES
(1, 'MAT', '2024-01-10', 2),
(1, 'PRG', '2024-01-15', 1),
(2, 'MAT', '2024-01-10', 3),
(3, 'PRG', '2024-01-20', 2),
(4, 'MAT', '2024-01-12', 4),
(4, 'FYZ', '2024-01-22', 1);
GO
