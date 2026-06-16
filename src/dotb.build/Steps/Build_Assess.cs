using System.Linq;
using Nuke.Common;
using Nuke.Common.Tools.DotNet;



public partial class Build : NukeBuild {



    Target UnitTest => _ => _
    .DependsOn(Compile)
    .Executes(() => {
        var testProjects = Solution.GetAllProjects("*.Test");
        if (testProjects.Any()) {
            DotNetTasks.DotNetTest(s => s
                .EnableNoRestore()
                .EnableNoBuild()
                .SetProjectFile(testProjects.First().Directory));
        }
    });

    Target ValidateStep => _ => _
     .DependsOn(Initialise, UnitTest, AssembleStep)
     .After(Compile)
     .Executes(() => {
         Logger.Info("--> Validate <-- ");


     });
}
