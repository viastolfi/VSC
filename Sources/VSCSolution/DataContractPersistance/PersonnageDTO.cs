﻿using BibliothequeClassesVSC;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DataContractPersistanceVSC
{
    [DataContract]
    public class PersonnageDTO
    {
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public HashSet<StatDTO> particularites = new HashSet<StatDTO>();
        [DataMember]
        public string NomArme { get; set; }
    }

    static class PersonnageExtensions
    {
        public static Personnage ToPOCO(this PersonnageDTO dto)
            => new Personnage(dto.Nom, dto.Description, dto.Image, dto.particularites.ToPOCOs().ToHashSet(), dto.NomArme);

        public static IEnumerable<Personnage> ToPOCOs(this IEnumerable<PersonnageDTO> dtos)
            => dtos.Select(dto => dto.ToPOCO());

        public static PersonnageDTO ToDTO(this Personnage poco)
            => new PersonnageDTO
            {
                Nom = poco.Nom,
                Description = poco.Description,
                Image = poco.Image,
                particularites = poco.particularites.ToDTOs().ToHashSet(),
                NomArme = poco.Arme.Nom
            };
        public static IEnumerable<PersonnageDTO> ToDTOs(this IEnumerable<Personnage> pocos)
            => pocos.Select(poco => poco.ToDTO());
    }
}
