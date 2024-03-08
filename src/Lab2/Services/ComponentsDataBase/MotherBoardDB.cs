using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComponentsDataBase;

public class MotherBoardDB : IBuildComponentDb<MotherBoard>
{
    public IList<MotherBoard> BuildComponentDb()
    {
        var motherBoardList = new List<MotherBoard>();
        var motherBoardBuilder = new MotherBoardBuilder();

        motherBoardList.Add(motherBoardBuilder.SetName("GIGABYTE B550 AORUS ELITE V2").
            SetBios(new BiosBuilder().SetName("Bios name").SetBiosType("Bios type").SetBiosVersion("Bios version").
                SetSupportedCpu(new List<string> { "Intel Core i7-11700F", "Intel Core i5-13500" }).GetResult()).
            SetSocketCpu("AM4").SetPcieLines(3).SetFormFactor("Standard-ATX").
            SetSlotsSata(4).SetChipset("AMD B550").SetDdrStandard("DDR4").SetRamFormFactor("DIMM").
            SetDdrSlots(4).GetResult());

        motherBoardList.Add(motherBoardBuilder.SetName("MSI MAG Z690 TOMAHAWK WIFI").
            SetSocketCpu("LGA 1700").SetPcieLines(3).
            SetSlotsSata(6).SetChipset("Intel Z690").SetDdrStandard("DDR5").
            SetDdrSlots(4).SetFormFactor("Standard-ATX").GetResult());

        motherBoardList.Add(motherBoardBuilder.SetName("ASRock B550M Pro4").
            SetSocketCpu("AM4").SetPcieLines(2).
            SetSlotsSata(6).SetChipset("AMD B550").SetDdrStandard("DDR4").
            SetDdrSlots(4).SetFormFactor("Micro-ATX").GetResult());

        motherBoardList.Add(motherBoardBuilder.SetName("ASUS PRIME Z590-P").
            SetSocketCpu("LGA 1200").SetPcieLines(2).
            SetSlotsSata(4).SetChipset("Intel Z590").SetDdrStandard("DDR4").
            SetDdrSlots(4).SetFormFactor("Standard-ATX").GetResult());

        return motherBoardList;
    }

    public IList<MotherBoard> AddNewComponent(IList<MotherBoard> newComponents)
    {
        ArgumentNullException.ThrowIfNull(newComponents);
        IList<MotherBoard> updatedDb = BuildComponentDb();
        foreach (MotherBoard tmp in newComponents)
        {
            if (!updatedDb.Contains(tmp))
            {
                updatedDb.Add(tmp);
            }
        }

        return updatedDb;
    }
}