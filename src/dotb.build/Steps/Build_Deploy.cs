using Nuke.Common;



public partial class Build : NukeBuild {


    Target DeployStep => _ => _
        .After(ReleaseStep)
        .DependsOn(Initialise, PrepareStep, Clean)
        .Executes(() => {
        });


}
