using UnityEngine;
using System.Collections;
using System;

namespace NewtonVR
{
    public class NVRLever : NVRInteractableItem
    {
       // public float LastValue;
        public float CurrentValue;
        public LeverPosition LastLeverPosition;
        public LeverPosition CurrentLeverPosition;
        public bool LeverEngaged = false;
        public float EngageWaitTime = 1f;
        //public GameObject other;
        public Rigidbody srb;
        public Rigidbody jointRigidbody;
        public GameObject AXLE;

        protected virtual float DeltaMagic { get { return 2f; } }
        protected Transform InitialAttachPoint;
        protected new HingeJoint hingeJoint;

        protected bool UseMotor;
        protected Quaternion Max, Mid, Min;
        protected float AngleRange;

        Quaternion prevRotation;

        bool isGrabbing
        { get { return InitialAttachPoint != null; } }

        protected override void Awake()
        {
     

            base.Awake();
            this.Rigidbody.maxAngularVelocity = 100f;

            if (hingeJoint == null)
            {
                hingeJoint = Rigidbody.gameObject.GetComponent<HingeJoint>();
            }

            Mid = hingeJoint.transform.localRotation;

            // Set initial rotation
            prevRotation = hingeJoint.transform.rotation;

            // Calculate min and max angle for lever rotation
            Max = Mid * Quaternion.AngleAxis(hingeJoint.limits.max, hingeJoint.axis);
            Min = Mid * Quaternion.AngleAxis(hingeJoint.limits.min, hingeJoint.axis);
            UseMotor = false;// this.hingeJoint.useMotor;

            //clamps min and max angles to never exceed the rotation
            if (hingeJoint.useLimits)
            {
                AngleRange = (Mathf.Max(hingeJoint.limits.max, hingeJoint.limits.min) - Mathf.Min(hingeJoint.limits.max, hingeJoint.limits.min));
            }
        }

        protected override void Update()
        {
            base.Update();

            //LeverEngaged = false;
            //LastValue = CurrentValue;
            // LastLeverPosition = CurrentLeverPosition;

            // If we're not grabbing the lever, freeze rotation. Otherwise, update it.
            //jointRigidbody.freezeRotation = !isGrabbing;
            jointRigidbody.constraints = isGrabbing ? 0 : RigidbodyConstraints.FreezeAll;
            //else
            //    prevRotation = hingeJoint.transform.rotation;


            CurrentValue = GetValue();
            CurrentLeverPosition = GetPosition();

            if (AXLE.transform.localRotation.z < 0)
                //addforce
                //srb.velocity = new Vector3(AXLE.transform.localRotation.z, 0, 0);
                srb.velocity = srb.transform.forward;
            else if (AXLE.transform.localRotation.z > 0)
                //addforce
              //  srb.velocity = new Vector3(AXLE.transform.localRotation.z, 0, 0);
                srb.velocity = -srb.transform.forward;
            //shipvelocity();

            //basically when lever is fully down it turns on 
            //if (LastLeverPosition != LeverPosition.On && CurrentLeverPosition == LeverPosition.On)
            // {
            //LeverEngaged = true;
            //Engage();
            //}
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        protected virtual void shipvelocity()
        {
            
      
            //else
              //  srb.velocity = new Vector3(0, 0, 0);
        }


        //protected virtual void Engage()
        //{
        //    //if (AttachedHand != null)
        //    //    AttachedHand.EndInteraction(this);

        //    //CanAttach = false;
        //    ////timer to make lever go back up
        //    //StartCoroutine(HoldPosition(EngageWaitTime));
        //}

        //private IEnumerator HoldPosition(float time)
        //{
        //    HingeJoint.useMotor = false;

        //    yield return new WaitForSeconds(time);

        //    HingeJoint.useMotor = true;
        //    CanAttach = true;
        //}

        ///

        public override void BeginInteraction(NVRHand hand)
        {
            base.BeginInteraction(hand);

            InitialAttachPoint = new GameObject(string.Format("[{0}] InitialAttachPoint", this.gameObject.name)).transform;
            InitialAttachPoint.position = hand.transform.position;
            InitialAttachPoint.rotation = hand.transform.rotation;
            InitialAttachPoint.localScale = Vector3.one * 0.25f;
            InitialAttachPoint.parent = this.transform;
            
            hingeJoint.useMotor = false;
        }

        public override void EndInteraction(NVRHand hand)
        {
            base.EndInteraction(hand);

           // HingeJoint.useMotor = true;

            if (InitialAttachPoint != null)
                Destroy(InitialAttachPoint.gameObject);
        }

        private float GetValue()
        {
            float m_diff = 0.0f;
            if (hingeJoint.useLimits)
            {
                m_diff = hingeJoint.angle - hingeJoint.limits.min;
            }
            return 1 - (m_diff / AngleRange);
        }

        private LeverPosition GetPosition()
        {
            if (CurrentValue <= 0.05)
                return LeverPosition.Off;
            else if (CurrentValue >= 0.95)
                return LeverPosition.On;

            return LeverPosition.Mid;
        }

        public enum LeverPosition
        {
            Off,
            Mid,
            On
        }

        public enum RotationAxis
        {
            XAxis,
            YAxis,
            ZAxis
        }
    }
}
