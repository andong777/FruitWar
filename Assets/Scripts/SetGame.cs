using UnityEngine;
using System.Collections;

public class SetGame: MonoBehaviour {

    private static SetGame _instance;   // singleton

	// Collider components
	public Transform leftWall;
	public Transform rightWall;
	public Transform topWall;
	public Transform bottomWall;

	// set pad and ball to original position
	private Transform pad = null;
	private Transform ball = null;
	
	// record some values
	private float leftPos;
	private float rightPos;
	private float topPos;
	private float bottomPos;
	
	// the bricks
	public GameObject[] bricks;
	float percentage = 0.75f;	// use how many spaces to generate bricks	

    private SetGame() {}

    public static SetGame Instance
    {
        get
        {
            return _instance;
        }
    }

	void Awake () {
        _instance = this;
		pad = GameObject.Find("Pad").transform;
		ball = GameObject.Find("Ball").transform;
		Random.seed = System.DateTime.Now.Millisecond;
	}

	// Use this for initialization
	void Start () {
		// get the border
        Camera mainCam = Camera.main;
		leftPos = mainCam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        rightPos = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        topPos = mainCam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        bottomPos = mainCam.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
		
		// set walls
		leftWall.position = new Vector3(leftPos - leftWall.gameObject.collider2D.bounds.size.x / 2, 0, 0);
		rightWall.position = new Vector3(rightPos + rightWall.gameObject.collider2D.bounds.size.x / 2, 0, 0);
		topWall.position = new Vector3(0, topPos + topWall.gameObject.collider2D.bounds.size.y / 2, 0);
		bottomWall.position = new Vector3(0, bottomPos - bottomWall.gameObject.collider2D.bounds.size.y / 2, 0);

        Reset();    // reset pad, ball and bricks
	}

    public void Reset()
    {
        // set the pad and the ball
        SetPadAndBall();
        // spawn bricks randomly.
        SpawnBricks();

    }

	public void SetPadAndBall() {
		// set pad position
		pad.position = new Vector3(0, bottomPos + pad.collider2D.bounds.size.y, 0);
		// set ball position
		ball.position = pad.position + new Vector3(0, ball.gameObject.collider2D.bounds.size.y / 2, 0);
		
		// mark the ball as unreleased
		Manager.Released = false;

		// return pad to normal
		pad.SendMessage("Reset");
		
		// return ball to normal
        ball.SendMessage("Reset");

	}
	
	public void SpawnBricks () {
		// get brick info. add a little distance between them
		float brickWidth = bricks[0].renderer.bounds.size.x * 1.1f;
		float brickHeight = bricks[0].renderer.bounds.size.y * 1.1f;
	
		// set block to spawn bricks
		float distX = (rightPos - leftPos) / 8;
		float distY = (topPos - bottomPos) / 4;
		float width = distX * 6;
		float height = distY * 3;
	
		// array to mark if a place is occupied
		int rowNum = (int)(width / brickWidth);
		int colNum = (int)(height / brickHeight);
		bool[,] used = new bool[rowNum, colNum];
		
		int brickCount = 0;	// count how many bricks are generated
		for(int i = 0; i < rowNum * colNum * percentage; i++){
			int row = Random.Range(0, rowNum - 1);
			int col = Random.Range(0, colNum - 1);
			if(!used[row, col]){
				used[row, col] = true;
				brickCount ++;
				int index = Random.Range(0, bricks.Length - 1);
				float x = leftPos + distX + brickWidth * (row + 0.5f);
				float y = bottomPos + distY + brickHeight * (col + 0.5f);
				Instantiate(bricks[index], new Vector3(x, y, 0), Quaternion.identity);
			}
		}
		
		Manager.SetTargetScoreByBrick(brickCount);	// set target score according to bricks
	}
}