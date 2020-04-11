using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMRecorder.DB
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public byte? Numero { get; set; }
        [StringLength(2)]
        public string Nationality { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(8)]
        public string FP { get; set; }
        public byte? Ada { get; set; }
        [StringLength(512)]
        public string Note { get; set; }
        public string ScoutVoto { get; set; }
        public string ScoutGiudizio { get; set; }
        public DateTime? FirstData { get; set; }
        public DateTime? LastData { get; set; }
        public string ScoutDate { get; set; }
        public string ScoutName { get; set; }
        public byte? Age { get; set; }
        public float? MediaVoto { get; set; }
        public int? ASI { get; set; }
        [StringLength(4)]
        public string Team { get; set; }
        public string TSI { get; set; }
        public int? Wage { get; set; }
        public float? AvRating { get; set; }
        public float? AvTSI { get; set; }
        public float? Blooming { get; set; }
        public float? Professionalism { get; set; }
        public float? Aggressivity { get; set; }
        public float? Leadership { get; set; }
        public float? Ability { get; set; }
        public byte? InjPron { get; set; }
        public int? wBorn { get; set; }
        public float? Routine { get; set; }
        [StringLength(256)]
        public string wBloomData { get; set; }
        public bool? isRetire { get; set; }
        public byte? isYoungTeam { get; set; }
        public string TrainingAbilities { get; set; }
        public short? FPn { get; set; }
        [StringLength(12)]
        public string Speciality { get; set; }
        public string GameTable { get; set; }
        public float? Potential { get; set; }
        public bool? HiddenRevealed { get; set; }
        public float? Rec { get; set; }
        public short? SPn { get; set; }

        internal void CopyData(ExtraDS.GiocatoriRow playerDS)
        {
            Name = playerDS.IsNomeNull() ? null : playerDS.Nome;
            Nationality = playerDS.IsNationalityNull() ? null : playerDS.Nationality;
            Ada = playerDS.IsAdaNull() ? (byte?)null : (byte)playerDS.Ada;
            FP = playerDS.IsFPNull() ? null : playerDS.FP;
            Note = playerDS.IsNoteNull() ? null : playerDS.Note;
            Numero =  (byte)playerDS.Numero;

            ScoutVoto = playerDS.IsScoutVotoNull() ? null : playerDS.ScoutVoto;
            ScoutGiudizio = playerDS.IsScoutGiudizioNull() ? null : playerDS.ScoutGiudizio;
            FirstData = playerDS.IsFirstDataNull() ? (DateTime?)null : playerDS.FirstData;
            LastData = playerDS.IsLastDataNull() ? (DateTime?)null : playerDS.LastData;
            ScoutDate = playerDS.IsScoutDateNull() ? null : playerDS.ScoutDate;
            ScoutName = playerDS.IsScoutNameNull() ? null : playerDS.ScoutName;
            Age = playerDS.IsEtàNull() ? (byte?) null : (byte)playerDS.Età;
            MediaVoto = playerDS.IsMediaVotoNull() ? (float?)null : playerDS.MediaVoto;
            ASI = playerDS.IsASINull() ? (int?)null : playerDS.ASI;
            Team = playerDS.IsTeamNull() ? null : playerDS.Team;
            TSI = playerDS.IsTSINull() ? null : playerDS.TSI;
            Wage = playerDS.IsWageNull() ? (int?)null : playerDS.Wage;
            AvRating = playerDS.IsAvRatingNull() ? (float?)null : playerDS.AvRating;
            AvTSI = playerDS.IsAvTSINull() ? (float?)null : playerDS.AvTSI;
            Blooming = playerDS.IsBloomingNull() ? (float?)null : playerDS.Blooming;
            Professionalism = playerDS.IsProfessionalismNull() ? (float?)null : playerDS.Professionalism;
            Aggressivity = playerDS.IsAggressivityNull() ? (float?)null : playerDS.Aggressivity;
            Leadership = playerDS.IsLeadershipNull() ? (float?)null : playerDS.Leadership;
            Ability = playerDS.IsAbilityNull() ? (float?)null : playerDS.Ability;
            InjPron = playerDS.IsInjPronNull() ? (byte?)null : (byte?)playerDS.InjPron;
            wBorn = playerDS.IswBornNull() ? (int?)null : (int?)playerDS.wBorn;
            Routine = playerDS.IsRoutineNull() ? (float?)null :(float?) playerDS.Routine;
            wBloomData = playerDS.IswBloomDataNull() ? null : playerDS.wBloomData;
            isRetire = playerDS.IsisRetireNull() ? (bool?)null : playerDS.isRetire;
            isYoungTeam = playerDS.IsisYoungTeamNull() ? (byte?)null : (byte?)playerDS.isYoungTeam;
            TrainingAbilities = playerDS.IsTrainingAbilitiesNull() ? null : playerDS.TrainingAbilities;
            FPn = playerDS.IsFPnNull() ? (short?)null : (short)playerDS.FPn;
            Speciality = playerDS.IsSpecialityNull() ? null : playerDS.Speciality;
            GameTable = playerDS.IsGameTableNull() ? null : playerDS.GameTable;
            Potential = playerDS.IsPotentialNull() ? (float?)null : playerDS.Potential;
            HiddenRevealed = playerDS.IsHiddenRevealedNull() ? (bool?)null : playerDS.HiddenRevealed;
            Rec = playerDS.IsRecNull() ? (float?)null : (float)playerDS.Rec;
            SPn = playerDS.IsSPnNull() ? (short?)null : (short)playerDS.SPn;
        }
    }
}
