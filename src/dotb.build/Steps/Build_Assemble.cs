using Nuke.Common;
using Nuke.Common.Tools.DotNet;


public partial class Build : NukeBuild {

    Target Restore => _ => _
       .Executes(() => {
       });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Triggers(UnitTest)
        .Executes(() => {

            DotNetTasks.DotNetBuild(s => s
              .SetProjectFile(Solution)
              .SetConfiguration(Configuration)
              .EnableNoRestore()
              .SetDeterministic(IsServerBuild)
              .SetContinuousIntegrationBuild(IsServerBuild)
          );


        });


    Target AssembleStep => _ => _
        .Before(ValidateStep)
        .DependsOn(Initialise, Compile)
        .Executes(() => {
        });

}

