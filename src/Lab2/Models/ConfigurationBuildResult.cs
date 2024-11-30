using Itmo.ObjectOrientedProgramming.Lab2.Entities.Configuration;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record ConfigurationBuildResult(PcConfiguration? Computer, bool Guarantee, string? Comment);