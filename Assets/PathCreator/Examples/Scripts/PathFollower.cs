using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 1;
        float distanceTravelled;
        public enum StartingPosition {StartPos, EndPos};
        public StartingPosition startingPosition = new StartingPosition();
        public int pause = 0;

    void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
            
        }

        void Update()
        {
            if(pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime * pause;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);

            }
        }


        public void SetEnd()
        {
            PauseMotion();
            distanceTravelled = 0;
            int lastIndex = pathCreator.path.NumPoints - 1;
            Debug.Log(lastIndex);
            transform.position = pathCreator.path.GetPoint(lastIndex);
            transform.rotation = pathCreator.path.GetRotation(lastIndex);
            
             

        }

        public void SetStart()
        {
            PauseMotion();
            distanceTravelled=0;
            transform.position = pathCreator.path.GetPoint(0);
            transform.rotation = pathCreator.path.GetRotation(0);
            

        }



        public void PauseMotion()
        {
            pause = 0;
            Debug.Log("Paused");
           
        }

        public void ResumeMotion()
        {
            pause = 1;
            Debug.Log("Resumed");
        }
     
        public void ToggleMotion()
        {
            if (pause == 1)
            {
                PauseMotion();
            }
            if (pause == 0)
            {
                ResumeMotion();
            }
        } 

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}