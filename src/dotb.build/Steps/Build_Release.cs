using Nuke.Common;



public partial class Build : NukeBuild {

    Target AspirateBuild => _ => _
      .Executes(() => {

      });

    Target ReleaseStep => _ => _
      .After(ValidateStep, Compile)
      .DependsOn(Initialise, AssembleStep, PrepareStep, AspirateBuild)
      .Executes(() => {
      });





}
