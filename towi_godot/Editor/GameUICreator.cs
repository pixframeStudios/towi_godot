using Godot;
using System;

public class GameUICreator : Node
{


        const string ASSETS_PATH = "Packages/com.pixframe-studios.towi-plugin/Assets";
        static GameObject GetOrCreateCanvas()
        {
            GameObject canvasObject;
            var canva = FindObjectOfType<Canvas>();
            if (!canva)
            {
                canvasObject = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
                canvasObject.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
                canvasObject.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
            }
            else
            {
                canvasObject = canva.gameObject;
            }
            return canvasObject;
        }
        static Dictionary<string, Sprite> GetUIButtonSprites()
        {
            var objects = AssetDatabase.LoadAllAssetsAtPath($"{ASSETS_PATH}/UI/GridBotones.png");
            var spriteDiccionary = objects.Where(q => q is Sprite).Cast<Sprite>().ToDictionary((sp)=> sp.name, (sp)=>sp);

            return spriteDiccionary;
        }

        #region Anchores

        static RectTransform SetAnchoredPos(GameObject gameObject)
        {
            return SetAnchoredPos(gameObject, new Vector2(0.5f, 1f), new Vector2(0.5f, 1f));
        }

        static RectTransform SetAnchoredPos(GameObject gameObject, Vector2 anchoredPos)
        {
            return SetAnchoredPos(gameObject, new Vector2(0.5f, 1f), new Vector2(0.5f, 1f), anchoredPos);
        }

        static RectTransform SetAnchoredPos(GameObject gameObject, Vector2 minAnchor, Vector2 maxAnchor)
        {
            return SetAnchoredPos(gameObject, minAnchor, maxAnchor, Vector2.zero);
        }

        static RectTransform SetAnchoredPos(GameObject gameObject, Vector2 minAnchor, Vector2 maxAnchor, Vector2 anchoredPos)
        {
            var rect = gameObject.GetComponent<RectTransform>();
            rect.anchorMin = minAnchor;
            rect.anchorMax = maxAnchor;
            rect.anchoredPosition = anchoredPos;
            return rect;
        }

        #endregion

        [MenuItem("GameObject/TowiUI/TowiPanel")]
        static GameObject CreateTowiPanel(GameObject canvas)
        {
            return CreateTowiPanel(canvas, new Vector2(400f, 200f));
        }

        static GameObject CreateTowiPanel(GameObject canvas, Vector2 panelSize)
        {
            var gameObject = new GameObject("GameResultPanel", typeof(Image));
            gameObject.transform.SetParent(canvas.transform);
            var panelImage = gameObject.GetComponent<Image>();
            var rect = SetAnchoredPos(gameObject, new Vector2(0f, -(panelSize.y / 2)));
            rect.sizeDelta = panelSize;
            var panelAsset = AssetDatabase.LoadAssetAtPath<Sprite>($"{ASSETS_PATH}/UI/Panel.png");
            panelImage.sprite = panelAsset;
            panelImage.type = Image.Type.Sliced;
            return gameObject;
        }

        static Image CreateStar(GameObject parent, int number, Vector2 starSize, Vector2 starPos)
        {
            var starAsset = AssetDatabase.LoadAssetAtPath<Sprite>($"{ASSETS_PATH}/UI/Star.png");
            var centerAnchor = Vector2.one * 0.5f;
            var buttonCreatedButton = CreateButton($"Star {number + 1}", parent, centerAnchor, centerAnchor, starPos, starAsset, starSize);
            return buttonCreatedButton.GetComponent<Image>();
        }

        static TextMeshProUGUI CreateText(string gameObjectName, GameObject parent, string textToShow, Vector2 textRectSize, Vector2 position, float fontSize = 20)
        {
            var font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>($"{ASSETS_PATH}/UI/Nunito.Asset");
            var newText = new GameObject(gameObjectName, typeof(TextMeshProUGUI)).GetComponent<TextMeshProUGUI>();
            newText.transform.SetParent(parent.transform);
            var gameResultTextRect = SetAnchoredPos(newText.gameObject, Vector2.up, Vector2.one, position);
            gameResultTextRect.sizeDelta = textRectSize;
            newText.text = textToShow;
            newText.fontSize = fontSize;
            newText.font = font;
            newText.alignment = TextAlignmentOptions.Midline;
            return newText;
        }

        static Button CreateButton(string buttonName, GameObject parent, Vector2 minAnchor, Vector2 maxAnchor, Vector2 anchoredPos, Sprite sprite, Vector2 buttonSize)
        {
            var newButton = new GameObject(buttonName, typeof(Button), typeof(Image)).GetComponent<Button>();
            newButton.transform.SetParent(parent.transform);
            var newButtonRect = SetAnchoredPos(newButton.gameObject, minAnchor, maxAnchor, anchoredPos);
            var newButtonImage = newButton.GetComponent<Image>();
            newButton.targetGraphic = newButtonImage;
            newButtonImage.sprite = sprite;
            newButtonRect.sizeDelta = buttonSize;
            return newButton;
        }

        [MenuItem("GameObject/TowiUI/GameResultPanel")]
        static void CreateResultPanel()
        {
            var canvas = GetOrCreateCanvas();

            var uiSprites = GetUIButtonSprites();

            Vector2 panelSize = new Vector2(400f, 200f);
            Vector2 textRectSize = new Vector2(-panelSize.y * 0.25f, (panelSize.y / 2f) - ((panelSize.y / 2f) * 0.1f));
            Vector2 buttonSize = new Vector2(32f, 32f);
            Vector2 starSize = new Vector2(48f, 48f);

            var panel = CreateTowiPanel(canvas, panelSize);
            var gameResult = panel.AddComponent<GameResultPanel>();

            var gameResultTextPos = new Vector2(0f, -(textRectSize.y / 2) - ((panelSize.y / 2f) * 0.15f));
            gameResult.text = CreateText("GameResultText", gameResult.gameObject, "Grade Towi", textRectSize, gameResultTextPos);

            gameResult.okButton = CreateButton("Ok Button", gameResult.gameObject, Vector2.right, Vector2.right, new Vector2((-buttonSize.x / 2), buttonSize.y / 2), uiSprites["Towi_Button_Ok"], buttonSize);


            gameResult.calificationImages = new Image[(int)GameResult.Excellent];
            float middle = (1 + (float)GameResult.Excellent) / 2f;
            float movement = (panelSize.x - (panelSize.x * 0.4f)) / (float)GameResult.Excellent;
            for (int i = 0; i < (int)GameResult.Excellent; i++)
            {
                Vector2 starPos = new Vector2(0f, -starSize.y / 2);
                float distanceFromMiddle = (i + 1) - middle;
                starPos.x = distanceFromMiddle * movement;
                var star = CreateStar(gameResult.gameObject, i, starSize, starPos);
                star.color = gameResult.onColor;
                gameResult.calificationImages[i] = star;
            }
        }
}
