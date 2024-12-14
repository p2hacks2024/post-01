using UnityEngine;

public class ScrollingBackgroundAndObjects : MonoBehaviour
{
    [SerializeField] private Transform background1; // 1���ڂ̔w�i
    [SerializeField] private Transform background2; // 2���ڂ̔w�i
    [SerializeField] private float scrollSpeed = 15f; // �w�i�̃X�N���[�����x
    [SerializeField] private GameObject[] objectPrefabs; // �o��������I�u�W�F�N�g��Prefab�z��
    [SerializeField] private float spawnInterval = 2f; // �I�u�W�F�N�g���o��������Ԋu
    [SerializeField] private Transform spawnArea; // �I�u�W�F�N�g�̏o���͈́i�㉺�ʒu�j

    private float backgroundWidth; // �w�i�̕�

    void Start()
    {
        // �w�i�摜�̕����擾
        SpriteRenderer bgRenderer = background1.GetComponent<SpriteRenderer>();
        backgroundWidth = bgRenderer.bounds.size.x;

        // ��莞�Ԃ��ƂɃI�u�W�F�N�g���o��������
        InvokeRepeating(nameof(SpawnObject), spawnInterval, spawnInterval);
    }

    void Update()
    {
        // �w�i�����ɃX�N���[��
        background1.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        background2.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // 1���ڂ̔w�i����ʊO�ɏo����ʒu�����Z�b�g
        if (background1.position.x <= -backgroundWidth)
        {
            background1.position += new Vector3(backgroundWidth * 2, 0, 0);
        }

        // 2���ڂ̔w�i����ʊO�ɏo����ʒu�����Z�b�g
        if (background2.position.x <= -backgroundWidth)
        {
            background2.position += new Vector3(backgroundWidth * 2, 0, 0);
        }
    }

    void SpawnObject()
    {
        // �Œ��X, Y���W�ɃI�u�W�F�N�g���o��������
        float spawnX = 1.4f; // �Œ��X���W
        float spawnY = 0f;  // �Œ��Y���W

        // �����_���Ƀv���n�u��I��
        int randomIndex = Random.Range(0, objectPrefabs.Length); // �z��͈͓̔��Ń����_���ȃC���f�b�N�X���擾
        GameObject randomPrefab = objectPrefabs[randomIndex];

        // �I�u�W�F�N�g�𐶐�
        GameObject spawnedObject = Instantiate(randomPrefab, new Vector3(background1.position.x + backgroundWidth, spawnY, 0), Quaternion.identity);

        // �I�u�W�F�N�g��w�i�Ɠ������x�ňړ�������
        spawnedObject.AddComponent<ScrollingObject>().SetSpeed(scrollSpeed);
    }
}

public class ScrollingObject : MonoBehaviour
{
    private float speed;

    public void SetSpeed(float scrollSpeed)
    {
        speed = scrollSpeed;
    }

    void Update()
    {
        // �w�i�Ɠ������x�ō��Ɉړ�
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // ��ʊO�ɏo����폜
        if (transform.position.x < -20f) // �K�؂ȍ폜�ʒu���w��
        {
            Destroy(gameObject);
        }
    }
}