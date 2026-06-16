using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.DotNet;
using Plisky.Nuke.Fusion;



public partial class Build : NukeBuild {

    Target PrepareStep => _ => _
        .Before(AssembleStep)
        .DependsOn(Initialise, Clean, MollyCheck)
        .Executes(() => {
        });

    Target Clean => _ => _
     .DependsOn(Initialise)
     .Before(PrepareStep)
     .Executes(() => {

         DotNetTasks.DotNetClean(s => s
          .SetProject(Solution));

         settings.ArtifactsDirectory.CreateOrCleanDirectory();
     });


    Target MollyCheck => _ => _
       .DependsOn(Initialise)
       .After(Clean)
       .Executes(() => {

           Logger.Info("Mollycoddle Structure Linting.");

           MollycoddleTasks.PerformScan(s => s
               .AddRuleHelp(true)
               .SetRulesFile(@"C:\files\code\git\mollycoddle\src\_Dependencies\RulesFiles\XXVERSIONNAMEXX\defaultrules.mollyset")
               .SetPrimaryRoot(@"C:\Files\OneDrive\Dev\PrimaryFiles")
               .SetDirectory(GitRepository.LocalDirectory));

       });
}
