using UnityEngine;

public class PointInTime
{
    public Vector3 position { get; set; }
    public Quaternion rotation { get; set; }
    public Vector3 velocity { get; set; }

    public PointInTime(Vector3 _position, Quaternion _rotation, Vector3 _velocity) {
        this.position = _position;
        this.rotation = _rotation;
        this.velocity = _velocity;
    }
}
