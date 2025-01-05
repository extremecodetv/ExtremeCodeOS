#define SDL_MAIN_USE_CALLBACKS 1
#include <SDL3/SDL.h>
#include <SDL3/SDL_main.h>

#define SDL_DEBUG_TEXT_FONT_CHARACTER_SIZE 32

#include <list>
#include <string>

using namespace std;

struct Vector2 { int x = 0, y = 0; };

enum class Direction
{
	Up,
	Left,
	Right,
	Down
};

struct Game
{
	void Construct(int field_size_x, int field_size_y)
	{
		fieldSize.x = field_size_x;
		fieldSize.y = field_size_y;
		Restart();
	}

	void GenerateApple()
	{
		applePos.x = rand() % fieldSize.x;
		applePos.y = rand() % fieldSize.y;
	}

	void Restart()
	{
		segments.clear();

		// Head is the segments.front()
		segments.push_back({ 5, 1 });
		segments.push_back({ 4, 1 });
		segments.push_back({ 3, 1 });
		segments.push_back({ 2, 1 });
		segments.push_back({ 1, 1 });

		direction = Direction::Right;

		previousTicks = SDL_GetTicks();

		isDead = false;
		score = 0;
		
		GenerateApple();
	}

	// Returns true if the snake has grown
	bool Update()
	{
		if (isDead)
			return false;

		bool result = false;
		Vector2 pos;

		auto construct_pos = [&](int dx, int dy)
			{
				pos.x = segments.front().x + dx;
				pos.y = segments.front().y + dy;
			};

		switch (direction)
		{
		case Direction::Up:    construct_pos(+0, -1); break;
		case Direction::Left:  construct_pos(-1, +0); break;
		case Direction::Right: construct_pos(+1, +0); break;
		case Direction::Down:  construct_pos(+0, +1); break;
		}

		if (pos.x < 0 || pos.y < 0 || pos.x >= fieldSize.x || pos.y >= fieldSize.y)
			isDead = true;

		segments.push_front(pos);

		if (pos.x == applePos.x && pos.y == applePos.y)
		{
			score++;
			result = true;

			GenerateApple();
			segments.push_back(segments.back());
		}

		segments.pop_back();

		for (auto i = segments.begin(); i != segments.end(); i++)
		{
			if (i != segments.begin() && i->x == segments.front().x && i->y == segments.front().y)
				isDead = true;
		}

		return result;
	}

	void Draw(SDL_Renderer* renderer)
	{
		SDL_SetRenderDrawColor(renderer, 0x20, 0x20, 0x20, 0xFF);
		SDL_RenderClear(renderer);

		SDL_SetRenderDrawColor(renderer, 0x00, 0xF6, 0x00, 0xFF);

		SDL_FRect rect;
		rect.w = tileSize.x;
		rect.h = tileSize.y;

		auto goto_xy = [&](const Vector2& p)
			{
				rect.x = p.x * tileSize.x;
				rect.y = p.y * tileSize.y;
			};

		for (const auto& s : segments)
		{
			goto_xy(s);
			SDL_RenderFillRect(renderer, &rect);
		}

		SDL_SetRenderDrawColor(renderer, 0xF0, 0x00, 0x00, 0xFF);

		goto_xy(applePos);
		SDL_RenderFillRect(renderer, &rect);

		SDL_RenderPresent(renderer);
	}

	list<Vector2> segments;
	Vector2 applePos;

	uint64_t previousTicks;

	Direction direction;

	Vector2 fieldSize;
	Vector2 tileSize = { 32, 32 };

	uint32_t score;
	bool isDead;
};

struct AppState
{
	AppState()
	{
		windowSize = { 1280, 800 };

		window = nullptr;
		renderer = nullptr;

		game.Construct(windowSize.x / game.tileSize.x, windowSize.y / game.tileSize.y);
	}

	void SetTitle(int score)
	{
		string text = "github.com/defini7 - Snake with SDL3! - Press SPACE to restart - Score: " + to_string(score);
		SDL_SetWindowTitle(window, text.c_str());
	}

	Vector2 windowSize;
	Game game;

	SDL_Window* window;
	SDL_Renderer* renderer;
};

SDL_AppResult SDL_AppInit(void** app_state, int argc, char* argv[])
{
	if (!SDL_SetAppMetadata("Snake", "0.1", "com.defini7.snake"))
		return SDL_APP_FAILURE;

	if (!SDL_Init(SDL_INIT_VIDEO))
		return SDL_APP_FAILURE;

	AppState* s = new AppState;
	*app_state = s;

	if (!SDL_CreateWindowAndRenderer("", s->windowSize.x, s->windowSize.y, 0, &s->window, &s->renderer))
		return SDL_APP_FAILURE;

	s->SetTitle(0);

	return SDL_APP_CONTINUE;
}

SDL_AppResult SDL_AppIterate(void* app_state)
{
	AppState* state = static_cast<AppState*>(app_state);
	Game& game = state->game;

	uint64_t ticks = SDL_GetTicks();

	if (ticks - game.previousTicks >= 100)
	{
		game.previousTicks = ticks;

		if (game.Update())
			state->SetTitle(game.score);
	}

	game.Draw(state->renderer);

	return SDL_APP_CONTINUE;
}

SDL_AppResult SDL_AppEvent(void* app_state, SDL_Event* event)
{
	AppState* state = static_cast<AppState*>(app_state);
	Game& game = state->game;

	switch (event->type)
	{
	case SDL_EVENT_QUIT: return SDL_APP_SUCCESS;
	case SDL_EVENT_KEY_DOWN:
	{
		switch (event->key.scancode)
		{
		case SDL_SCANCODE_W:     game.direction = Direction::Up;    break;
		case SDL_SCANCODE_S:     game.direction = Direction::Down;  break;
		case SDL_SCANCODE_A:     game.direction = Direction::Left;  break;
		case SDL_SCANCODE_D:     game.direction = Direction::Right; break;
		case SDL_SCANCODE_SPACE: game.Restart();                    break;

		}
	}
	break;

	}

	return SDL_APP_CONTINUE;
}

void SDL_AppQuit(void* app_state, SDL_AppResult result)
{
	AppState* state = static_cast<AppState*>(app_state);

	if (state)
	{
		SDL_DestroyRenderer(state->renderer);
		SDL_DestroyWindow(state->window);
		delete state;
	}
}
