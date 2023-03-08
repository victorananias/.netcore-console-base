-- Geração do código da model em C#
DECLARE @TableName NVARCHAR(500) = 'NomeDaTabela'
DECLARE @ClassName NVARCHAR(500) = REPLACE(@TableName, '_', '') -- opcional: remover underscore
DECLARE @Properties NVARCHAR(MAX) = ''

SELECT 
    @Properties = @Properties + 
    CHAR(10) + '    public ' + 
    CASE 
        WHEN DATA_TYPE IN ('int', 'bigint', 'smallint', 'tinyint') THEN 'int'
        WHEN DATA_TYPE IN ('decimal', 'numeric', 'float', 'real') THEN 'decimal'
        WHEN DATA_TYPE IN ('char', 'varchar', 'text', 'nchar', 'nvarchar', 'ntext') THEN 'string'
        WHEN DATA_TYPE IN ('datetime', 'datetime2', 'date', 'time') THEN 'DateTime'
        WHEN DATA_TYPE IN ('bit') THEN 'bool'
        WHEN DATA_TYPE IN ('uniqueidentifie') THEN 'Guid'
        ELSE 'object'
    END + ' ' + COLUMN_NAME + ' { get; set; }'
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = @TableName

PRINT 'public class ' + @ClassName + ' {' + @Properties + CHAR(10) + '}'
