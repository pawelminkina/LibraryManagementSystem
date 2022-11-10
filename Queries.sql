
--OPTION 1
--Getting group with all includes
exec sp_executesql N'SELECT [t].[Id], [t].[Name], [t0].[Id], [t0].[LibraryGroupId], [t0].[Name], [t0].[Id0], [t0].[LibraryId], [t0].[Title], [t0].[Id00], [t0].[BookId], [t0].[Content], [t0].[Number]
FROM (
    SELECT TOP(1) [l].[Id], [l].[Name]
    FROM [LibraryGroups] AS [l]
    WHERE [l].[Id] = @__groupId_0
) AS [t]
LEFT JOIN (
    SELECT [l0].[Id], [l0].[LibraryGroupId], [l0].[Name], [t1].[Id] AS [Id0], [t1].[LibraryId], [t1].[Title], [t1].[Id0] AS [Id00], [t1].[BookId], [t1].[Content], [t1].[Number]
    FROM [Libraries] AS [l0]
    LEFT JOIN (
        SELECT [b].[Id], [b].[LibraryId], [b].[Title], [p].[Id] AS [Id0], [p].[BookId], [p].[Content], [p].[Number]
        FROM [Books] AS [b]
        LEFT JOIN [Pages] AS [p] ON [b].[Id] = [p].[BookId]
    ) AS [t1] ON [l0].[Id] = [t1].[LibraryId]
) AS [t0] ON [t].[Id] = [t0].[LibraryGroupId]
ORDER BY [t].[Id], [t0].[Id], [t0].[Id0]',N'@__groupId_0 uniqueidentifier',@__groupId_0='E7B2E4FF-9C8A-45C4-AEC5-F949D419B9C0'

--OPTION 2
--Getting library group by id for validation
exec sp_executesql N'SELECT TOP(1) [l].[Id], [l].[Name]
FROM [LibraryGroups] AS [l]
WHERE [l].[Id] = @__request_GroupId_0',N'@__request_GroupId_0 uniqueidentifier',@__request_GroupId_0='E7B2E4FF-9C8A-45C4-AEC5-F949D419B9C0'

--Getting pages with includes
exec sp_executesql N'SELECT [l].[Id], [l].[LibraryGroupId], [l].[Name], [l0].[Id], [t].[Id], [t].[LibraryId], [t].[Title], [t].[Id0], [t].[BookId], [t].[Content], [t].[Number]
FROM [Libraries] AS [l]
INNER JOIN [LibraryGroups] AS [l0] ON [l].[LibraryGroupId] = [l0].[Id]
LEFT JOIN (
    SELECT [b].[Id], [b].[LibraryId], [b].[Title], [p].[Id] AS [Id0], [p].[BookId], [p].[Content], [p].[Number]
    FROM [Books] AS [b]
    LEFT JOIN [Pages] AS [p] ON [b].[Id] = [p].[BookId]
) AS [t] ON [l].[Id] = [t].[LibraryId]
WHERE [l0].[Id] = @__request_GroupId_0
ORDER BY [l].[Id], [l0].[Id], [t].[Id]',N'@__request_GroupId_0 uniqueidentifier',@__request_GroupId_0='E7B2E4FF-9C8A-45C4-AEC5-F949D419B9C0'

--OPTION 3
--Getting library group by id for validation (Look that I'm retriving only name)
exec sp_executesql N'SELECT TOP(1) [l].[Name]
FROM [LibraryGroups] AS [l]
WHERE [l].[Id] = @__request_GroupId_0',N'@__request_GroupId_0 uniqueidentifier',@__request_GroupId_0='E7B2E4FF-9C8A-45C4-AEC5-F949D419B9C0'

--Getting pages with select
exec sp_executesql N'SELECT [l].[Name], [l].[Id], [l0].[Id], [t0].[Id], [t0].[Content], [t0].[Id0]
FROM [Libraries] AS [l]
INNER JOIN [LibraryGroups] AS [l0] ON [l].[LibraryGroupId] = [l0].[Id]
LEFT JOIN (
    SELECT [b].[Id], [t].[Content], [t].[Id] AS [Id0], [t].[Number], [b].[LibraryId]
    FROM [Books] AS [b]
    LEFT JOIN (
        SELECT [p].[Content], [p].[Id], [p].[Number], [p].[BookId]
        FROM [Pages] AS [p]
    ) AS [t] ON [b].[Id] = [t].[BookId]
) AS [t0] ON [l].[Id] = [t0].[LibraryId]
WHERE [l0].[Id] = @__request_GroupId_0
ORDER BY [l].[Id], [l0].[Id], [t0].[Id], [t0].[Number]',N'@__request_GroupId_0 uniqueidentifier',@__request_GroupId_0='E7B2E4FF-9C8A-45C4-AEC5-F949D419B9C0'