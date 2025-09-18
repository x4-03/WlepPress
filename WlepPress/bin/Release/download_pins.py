import os
from pinterest_dl import PinterestDL
from pathlib import Path

def download_until_duplicate_id():
    """Download images until finding first duplicate ID"""
    
    # Your specific board and directory
    board_url = "https://pinterest.com/ogkrej/wlepy/"
    download_dir =  Path.home() / r"Downloads\pinwlepy"
    
    # Create directory if it doesn't exist
    os.makedirs(download_dir, exist_ok=True)
    
    print(f"Downloading images from: {board_url}")
    print(f"Saving to: {download_dir}")
    print("Will stop at first duplicate ID...")
    
    # Initialize PinterestDL
    try:
        dl = PinterestDL.with_api(verbose=True)
    except Exception as e:
        print(f"Error initializing PinterestDL: {e}")
        return
    
    # Scrape the board
    try:
        print("Scraping board for images...")
        media_items = dl.scrape(board_url, num=9999)
        print(f"Found {len(media_items)} items on the board")
    except Exception as e:
        print(f"Error scraping board: {e}")
        return
    
    # Get existing file IDs
    existing_ids = set()
    for filename in os.listdir(download_dir):
        if filename.lower().endswith(('.png', '.jpg', '.jpeg')):
            # Extract ID from filename (assuming format is "ID.jpg")
            file_id = os.path.splitext(filename)[0]
            existing_ids.add(file_id)
    
    print(f"Found {len(existing_ids)} existing images in destination folder")
    
    # Download new images until we find a duplicate ID
    downloaded_count = 0
    duplicate_found = False
    
    for i, item in enumerate(media_items):
        if duplicate_found:
            break
            
        item_id = str(item.id)
        print(f"Processing item {i+1}/{len(media_items)} (ID: {item_id})...")
        
        # Check if we already have this ID6
        if item_id in existing_ids:
            print(f"Duplicate ID found: {item_id}! Stopping download.")
            duplicate_found = True
            break
        
        try:
            # Download the image
            dl.download_media([item], output_dir=download_dir, download_streams=False)
            downloaded_count += 1
            print(f"Downloaded: {item_id}.jpg")
            
            # Add to our tracked IDs
            existing_ids.add(item_id)
                
        except Exception as e:
            print(f"Error downloading item {item_id}: {e}")
            continue
    
    print(f"Download completed! Downloaded {downloaded_count} new images.")
    if duplicate_found:
        print("Stopped at first duplicate ID.")
    else:
        print("No duplicate IDs found - downloaded all available images.")

if __name__ == "__main__":
    download_until_duplicate_id()