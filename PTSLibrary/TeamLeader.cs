namespace PTSLibrary
{
    [Serializable]
    public class TeamLeader : User
    {
        private int cohortId;

        public int CohortId
        {
            get { return cohortId; }
            set { cohortId = value; }
        }

        public TeamLeader(string name, int id, int cohortId)
        {
            this.name = name;
            this.id = id;
            this.cohortId = cohortId;
        }
    }
}