using UnityEngine;

namespace Aty
{
    public class CameraFollow : MonoBehaviour
    {

        //[SerializeField]
        //Transform target = null;

        [SerializeField]
        public Vector3 distance;

        [SerializeField]
        int lag = 0;

        [SerializeField] Vector3 minLimit = new Vector3(-5000, -5000, -5000);
        [SerializeField] Vector3 maxLimit = new Vector3(+5000, +5000, +5000);

        Vector3[] before = null;

        private Transform _target = null;
        public Transform target
        {
            get
            {
                if (!_target)
                {
                    var temp = FindObjectOfType<PlayerMovement>();
                    if (temp) _target = temp.transform;
                }
                return _target;
            }
        }

        private void OnEnable()
        {
            before = new Vector3[lag];
            if (!target) return;
            for (int i = 0; i < before.Length; i++) before[i] = target.position;
        }

        private void OnValidate()
        {
            lag = lag < 0 ? 0 : lag;
        }

        private void FixedUpdate()
        {
            if (!target) return;
            if (lag == 0 || before == null || before.Length == 0) transform.position = target.position + distance;

            else
            {
                transform.position = (before[0] + distance).Clamp(minLimit, maxLimit);
                for (int i = 0; i < before.Length - 1; i++) before[i] = before[i + 1];
                before[before.Length - 1] = target.position;
            }

        }

        public int Lag
        {
            get
            {

                return lag;
            }
            set
            {
                if (value == lag) return;
                if (value < 0) value = 0;

                Vector3[] temp = new Vector3[value];
                for (int i = 0; i < value && i < lag; i++) temp[i] = before[i];
                for (int i = lag; i < value; i++) temp[i] = before[before.Length - 1];

                before = temp;
                lag = value;
            }
        }
    }
}