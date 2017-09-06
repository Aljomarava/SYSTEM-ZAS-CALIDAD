namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Asisten : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsistenciaAlumno",
                c => new
                    {
                        AsistenciaAlumnoId = c.Int(nullable: false, identity: true),
                        FechaAsistencia = c.DateTime(nullable: false),
                        SeccionId = c.Int(nullable: false),
                        DocenteId = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                        AlumnoId = c.Int(nullable: false),
                        AnioAcademicoId = c.Int(nullable: false),
                        Curso_SeccionId = c.Int(),
                        Docente_SeccionId = c.Int(),
                        Seccion_SeccionId = c.Int(),
                    })
                .PrimaryKey(t => t.AsistenciaAlumnoId)
                .ForeignKey("dbo.Alumnos", t => t.AlumnoId)
                .ForeignKey("dbo.AnioAcademico", t => t.AnioAcademicoId)
                .ForeignKey("dbo.Seccion", t => t.Curso_SeccionId)
                .ForeignKey("dbo.Seccion", t => t.Docente_SeccionId)
                .ForeignKey("dbo.Seccion", t => t.Seccion_SeccionId)
                .Index(t => t.AlumnoId)
                .Index(t => t.AnioAcademicoId)
                .Index(t => t.Curso_SeccionId)
                .Index(t => t.Docente_SeccionId)
                .Index(t => t.Seccion_SeccionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsistenciaAlumno", "Seccion_SeccionId", "dbo.Seccion");
            DropForeignKey("dbo.AsistenciaAlumno", "Docente_SeccionId", "dbo.Seccion");
            DropForeignKey("dbo.AsistenciaAlumno", "Curso_SeccionId", "dbo.Seccion");
            DropForeignKey("dbo.AsistenciaAlumno", "AnioAcademicoId", "dbo.AnioAcademico");
            DropForeignKey("dbo.AsistenciaAlumno", "AlumnoId", "dbo.Alumnos");
            DropIndex("dbo.AsistenciaAlumno", new[] { "Seccion_SeccionId" });
            DropIndex("dbo.AsistenciaAlumno", new[] { "Docente_SeccionId" });
            DropIndex("dbo.AsistenciaAlumno", new[] { "Curso_SeccionId" });
            DropIndex("dbo.AsistenciaAlumno", new[] { "AnioAcademicoId" });
            DropIndex("dbo.AsistenciaAlumno", new[] { "AlumnoId" });
            DropTable("dbo.AsistenciaAlumno");
        }
    }
}
