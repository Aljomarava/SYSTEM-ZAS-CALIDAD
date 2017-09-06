namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AS : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AsistenciaAlumno", new[] { "Curso_SeccionId" });
            DropIndex("dbo.AsistenciaAlumno", new[] { "Docente_SeccionId" });
            DropIndex("dbo.AsistenciaAlumno", new[] { "Seccion_SeccionId" });
            DropColumn("dbo.AsistenciaAlumno", "CursoId");
            DropColumn("dbo.AsistenciaAlumno", "DocenteId");
            DropColumn("dbo.AsistenciaAlumno", "SeccionId");
            RenameColumn(table: "dbo.AsistenciaAlumno", name: "Curso_SeccionId", newName: "CursoId");
            RenameColumn(table: "dbo.AsistenciaAlumno", name: "Docente_SeccionId", newName: "DocenteId");
            RenameColumn(table: "dbo.AsistenciaAlumno", name: "Seccion_SeccionId", newName: "SeccionId");
            AlterColumn("dbo.AsistenciaAlumno", "CursoId", c => c.Int(nullable: false));
            AlterColumn("dbo.AsistenciaAlumno", "DocenteId", c => c.Int(nullable: false));
            AlterColumn("dbo.AsistenciaAlumno", "SeccionId", c => c.Int(nullable: false));
            CreateIndex("dbo.AsistenciaAlumno", "SeccionId");
            CreateIndex("dbo.AsistenciaAlumno", "DocenteId");
            CreateIndex("dbo.AsistenciaAlumno", "CursoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AsistenciaAlumno", new[] { "CursoId" });
            DropIndex("dbo.AsistenciaAlumno", new[] { "DocenteId" });
            DropIndex("dbo.AsistenciaAlumno", new[] { "SeccionId" });
            AlterColumn("dbo.AsistenciaAlumno", "SeccionId", c => c.Int());
            AlterColumn("dbo.AsistenciaAlumno", "DocenteId", c => c.Int());
            AlterColumn("dbo.AsistenciaAlumno", "CursoId", c => c.Int());
            RenameColumn(table: "dbo.AsistenciaAlumno", name: "SeccionId", newName: "Seccion_SeccionId");
            RenameColumn(table: "dbo.AsistenciaAlumno", name: "DocenteId", newName: "Docente_SeccionId");
            RenameColumn(table: "dbo.AsistenciaAlumno", name: "CursoId", newName: "Curso_SeccionId");
            AddColumn("dbo.AsistenciaAlumno", "SeccionId", c => c.Int(nullable: false));
            AddColumn("dbo.AsistenciaAlumno", "DocenteId", c => c.Int(nullable: false));
            AddColumn("dbo.AsistenciaAlumno", "CursoId", c => c.Int(nullable: false));
            CreateIndex("dbo.AsistenciaAlumno", "Seccion_SeccionId");
            CreateIndex("dbo.AsistenciaAlumno", "Docente_SeccionId");
            CreateIndex("dbo.AsistenciaAlumno", "Curso_SeccionId");
        }
    }
}
