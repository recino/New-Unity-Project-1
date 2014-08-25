using UnityEngine;
using System.Collections;

public class YourHealth : MonoBehaviour {
	public int startingHelth;
	public int healthPerPart;
	private int maxHealth;
	
	private int currentHealth;
	private int tempHealth;

	public GUITexture heartGUI;
	public Texture[] images;
	
	private ArrayList hearts = new ArrayList();
	
	public int maxHeartsPerRow;
	private float spacingX;
	private float spacingY;
	
	// Use this for initialization
	void Start () {
		currentHealth = startingHelth;
		spacingX = heartGUI.pixelInset.width;
		spacingY = -heartGUI.pixelInset.height;
		AddHearts(startingHelth/healthPerPart);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void AddHearts(int n)
	{
		for (int i = 0; i < n; i++ )
		{
			Transform newHeart = ((GameObject) Instantiate(heartGUI.gameObject, this.transform.position, Quaternion.identity)).transform;
			newHeart.parent = transform;
			
			int y = Mathf.FloorToInt(hearts.Count / maxHeartsPerRow);
			int x = hearts.Count - y * maxHeartsPerRow;
			
			newHeart.GetComponent<GUITexture>().pixelInset = new Rect(x * spacingX,y * spacingY,58,58);
			newHeart.GetComponent<GUITexture>().texture = images[0];
			hearts.Add(newHeart);
			
		}
		
		maxHealth += n * healthPerPart;
		currentHealth = maxHealth;
		UpdateHearts();
	}
	
	public void ModifyHealth(int amount)
	{
			currentHealth += amount;
			currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
			UpdateHearts();
	}
	
	void UpdateHearts() {
		bool restAreEmpty = false;
		int i =0;
		float imageIndex;
		
		foreach (Transform heart in hearts) {

			if (restAreEmpty) {
				heart.guiTexture.texture = images[0]; // heart is empty
			}
			else {
				i += 1; // current iteration
				if (currentHealth >= i * healthPerPart) {
					heart.guiTexture.texture = images[images.Length-1]; // health of current heart is full
				}
				else {
					int currentHeartHealth = (healthPerPart - (healthPerPart * i - currentHealth));
					float healthPerImage = ((float)healthPerPart) / (images.Length -1); // how much health is there per image
					healthPerImage = Mathf.Round(healthPerImage);
					imageIndex = currentHeartHealth / healthPerImage;
					if (imageIndex <= 3.99 && imageIndex >= 3.01 )
					{
						imageIndex = 4;
						heart.guiTexture.texture = images[(int)imageIndex];
						restAreEmpty = true;
					}

					else if (imageIndex <= 3 && imageIndex >= 2.01)
					{
						imageIndex = 3;
						heart.guiTexture.texture = images[(int)imageIndex];
						restAreEmpty = true;
					}

					else if (imageIndex <= 2 && imageIndex >= 1.01)
					{
						imageIndex = 2;
						heart.guiTexture.texture = images[(int)imageIndex];
						restAreEmpty = true;
					}

					else if (imageIndex <= 1 && imageIndex >= .01)
					{
						imageIndex = 1;
						heart.guiTexture.texture = images[(int)imageIndex];
						restAreEmpty = true;
					}
					else if (imageIndex == 0){
						heart.guiTexture.texture = images[(int)imageIndex];
						restAreEmpty = true;
					}
				}
			}
		}
	}
}
