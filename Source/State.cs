using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Plets.Core.FiniteStateMachine {
    /// <summary>
    /// Represents a finite state machine state model.
    /// </summary>
    [Serializable]
    public class State : IComparable {
        #region Constructors
        /// <summary>
        /// Parameterless constructor. Used by XmlSerializer.
        /// </summary>
        public State () {
            Transitions = new List<Transition> ();
            TaggedValues = new Dictionary<String, String> ();
        }
        /// <summary>
        /// Default constructor.
        /// </summary>
        public State (String name) {
            this.Name = name;
            Transitions = new List<Transition> ();
            TaggedValues = new Dictionary<String, String> ();
        }
        #endregion

        /// <summary>
        /// Identifies the state on a fsm.
        /// </summary>
        [XmlAttribute ()]
        public String Id {
            get;
            set;
        }
        /// <summary>
        /// Name property.
        /// </summary>
        [XmlAttribute ()]
        public String Name { get; set; }

        public List<Transition> Transitions {
            get;
            set;
        }

        public Dictionary<String, String> TaggedValues {
            get;
            set;
        }
        //public void Addtransition(Transition t)
        //{
        //    Transitions.Add(t);
        //}

        public FiniteStateMachine FiniteStateMachine {
            get;
            set;
        }

        #region Methods
        /// <summary>
        /// Returns true if this state is the initial state of given finite state machine.
        /// </summary>
        /// <param name="fsm"></param>
        /// <returns></returns>
        public Boolean IsInitialState (FiniteStateMachine fsm) {
            return (fsm.InitialState.Equals (this));
        }
        /// <summary>
        /// Compare to implementation.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo (object obj) {
            if (obj is State) {
                State s = (State) obj;
                if (this.Name.Equals (s.Name))
                    return 0;
                return 1;
            } else {
                return -1;
            }
        }

        public override string ToString () {
            return this.Name;
        }

        public override bool Equals (object obj) {
            if (obj == null || GetType () != obj.GetType ()) {
                return false;
            }

            if (((State) obj).Name.Equals (this.Name))
                return true;

            return false;
        }

        // override object.GetHashCode
        public override int GetHashCode () {
            return this.Name.GetHashCode ();
        }
        #endregion
    }
}