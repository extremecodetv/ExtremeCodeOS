import speedtest

def check_net_speed():
	speed = speedtest.SpeedTest()

	download_speed = speed.download()

	upload_speed = speed.upload()

	print(f'The download speed = {download_speed}')

	print(f'The upload speed = {upload_speed}')
