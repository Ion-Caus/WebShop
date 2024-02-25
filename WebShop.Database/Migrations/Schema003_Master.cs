using Migr8;

namespace WebShop.Database.Migrations;

[Migration(3, "Create images table")]
public class Schema003_Master : ISqlMigration
{
    public string Sql => @"
CREATE TABLE [dbo].[Images] (
    [Id] INT IDENTITY NOT NULL,
    [Title] NVARCHAR(255) NOT NULL,
    [Data] VARBINARY(MAX) NOT NULL,
    
    CONSTRAINT [PK_Images] PRIMARY KEY ([Id])
);

ALTER TABLE [dbo].[Products] DROP COLUMN [ImageUrl];

ALTER TABLE [dbo].[Products] ADD [ImageId] INT NULL;
ALTER TABLE [dbo].[Products] ADD CONSTRAINT [FK_Products_Images_ImageId] FOREIGN KEY ([ImageId]) REFERENCES [dbo].[Images] ([Id]);
";
}