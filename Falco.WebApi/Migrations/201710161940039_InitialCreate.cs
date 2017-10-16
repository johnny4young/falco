namespace Falco.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cita",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PacientId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        TipoCitaId = c.Int(nullable: false),
                        paciente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paciente", t => t.paciente_Id)
                .ForeignKey("dbo.TipoCita", t => t.TipoCitaId, cascadeDelete: true)
                .Index(t => t.TipoCitaId)
                .Index(t => t.paciente_Id);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Edad = c.Int(nullable: false),
                        Sexo = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoCita",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cita", "TipoCitaId", "dbo.TipoCita");
            DropForeignKey("dbo.Cita", "paciente_Id", "dbo.Paciente");
            DropIndex("dbo.Cita", new[] { "paciente_Id" });
            DropIndex("dbo.Cita", new[] { "TipoCitaId" });
            DropTable("dbo.TipoCita");
            DropTable("dbo.Paciente");
            DropTable("dbo.Cita");
        }
    }
}
